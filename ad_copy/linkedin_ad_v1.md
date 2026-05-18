typescript
/**
 * LinkedIn Ad Copy – Awareness Phase Module
 *
 * This module defines the structure, validation, and logging for a LinkedIn ad campaign
 * targeting Jamaican investors. It provides two ad variants with full type safety,
 * input validation, and error handling.
 *
 * @module linkedin-ad-copy
 */

import { createLogger, format, transports } from 'winston';

// ============================================================
// Logging Configuration
// ============================================================

const logger = createLogger({
  level: process.env.LOG_LEVEL || 'info',
  format: format.combine(
    format.timestamp({ format: 'YYYY-MM-DD HH:mm:ss' }),
    format.errors({ stack: true }),
    format.json()
  ),
  defaultMeta: { service: 'linkedin-ad-copy' },
  transports: [
    new transports.Console({
      format: format.combine(
        format.colorize(),
        format.simple()
      )
    }),
    new transports.File({ filename: 'error.log', level: 'error' }),
    new transports.File({ filename: 'combined.log' })
  ]
});

// ============================================================
// Type Definitions
// ============================================================

/**
 * Validation severity levels.
 * Used internally to control whether a violation throws or logs a warning.
 */
type ValidationSeverity = 'error' | 'warn';

/**
 * Generic constraint for ad copy fields that must be non-empty strings.
 */
interface NonEmptyString {
  readonly value: string;
  readonly fieldName: string;
}

/**
 * Represents a single call-to-action object.
 */
interface CTA {
  /** Display text shown on the CTA button/link. */
  readonly text: string;
  /** Destination URL or placeholder (e.g., landing page, webinar registration). */
  readonly url: string;
}

/**
 * Defines the structure for an image description accompanying the ad.
 */
interface AdVisualDescription {
  /** A brief, professional description of the image. */
  readonly description: string;
}

/**
 * A structured ad variant containing all required copy components.
 */
interface AdVariant {
  /** Unique identifier for the variant (e.g., 'A', 'B'). */
  readonly variantId: string;
  /** Headline text for the ad. */
  readonly headline: string;
  /** Body copy of the ad. */
  readonly body: string;
  /** Call-to-action object. */
  readonly cta: CTA;
  /** Optional visual description for creative asset. */
  readonly visual?: AdVisualDescription;
}

/**
 * The complete campaign configuration including metadata.
 */
interface CampaignConfig {
  /** Campaign name */
  readonly campaignName: string;
  /** Campaign objective (e.g., 'Awareness', 'Consideration', 'Conversion') */
  readonly objective: string;
  /** Target audience description */
  readonly targetAudience: string;
  /** Primary call to action description (not the link, but the intended user action) */
  readonly primaryAction: string;
  /** Array of ad variants */
  readonly variants: ReadonlyArray<AdVariant>;
}

// ============================================================
// Validation Errors & Utilities
// ============================================================

/**
 * Custom error for invalid campaign configurations.
 */
class CampaignValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'CampaignValidationError';

    // Maintain proper stack trace (available in V8 environments)
    if (Error.captureStackTrace) {
      Error.captureStackTrace(this, CampaignValidationError);
    }
  }
}

/**
 * Validates that a value is a non-empty string.
 * @param value - The value to validate.
 * @param fieldName - Human-readable name of the field for error messages.
 * @param severity - If 'warn', logs a warning instead of throwing.
 * @throws {CampaignValidationError} If severity is 'error' and validation fails.
 */

function validateNonEmptyString(
  value: unknown,
  fieldName: string,
  severity: ValidationSeverity = 'error'
): asserts value is string {
  if (typeof value !== 'string' || value.trim().length === 0) {
    const message = `Validation failed for '${fieldName}': expected a non-empty string, got ${typeof value} with value '${String(value)}'.`;
    if (severity === 'error') {
      logger.error(message);
      throw new CampaignValidationError(message);
    } else {
      logger.warn(message);
    }
  }
}

/**
 * Validates that an object has the required CTA fields.
 * @param cta - Potential CTA object.
 * @throws {CampaignValidationError} If CTA is invalid.
 */
function validateCTA(cta: unknown): asserts cta is CTA {
  if (typeof cta !== 'object' || cta === null) {
    throw new CampaignValidationError('CTA must be an object.');
  }
  const obj = cta as Record<string, unknown>;
  validateNonEmptyString(obj.text, 'cta.text');
  validateNonEmptyString(obj.url, 'cta.url');
}

/**
 * Validates an entire AdVariant object.
 * @param variant - Potential ad variant.
 * @throws {CampaignValidationError} If any required field is missing/invalid.
 */

function validateAdVariant(variant: unknown): asserts variant is AdVariant {
  if (typeof variant !== 'object' || variant === null) {
    throw new CampaignValidationError('Ad variant must be an object.');
  }
  const v = variant as Record<string, unknown>;

  // Required string fields
  const stringFields: Array<{ key: string; label: string }> = [
    { key: 'variantId', label: 'variantId' },
    { key: 'headline', label: 'headline' },
    { key: 'body', label: 'body' }
  ];
  for (const field of stringFields) {
    validateNonEmptyString(v[field.key], field.label);
  }

  // Validate nested CTA object
  validateCTA(v.cta);

  // If visual is present, validate it (optional)
  if (v.visual !== undefined) {
    if (typeof v.visual !== 'object' || v.visual === null) {
      logger.warn('visual field must be an object if present.');
    } else {
      const visual = v.visual as Record<string, unknown>;
      validateNonEmptyString(visual.description, 'visual.description', 'warn');
    }
  }

  // Check for unexpected keys that might indicate typos
  const allowedKeys = ['variantId', 'headline', 'body', 'cta', 'visual'];
  const extraKeys = Object.keys(v).filter(key => !allowedKeys.includes(key));
  if (extraKeys.length > 0) {
    logger.warn(`Ad variant has unexpected keys: ${extraKeys.join(', ')}. These will be ignored.`);
  }
}

/**
 * Validates the entire campaign configuration.
 * @param config - Config to validate.
 * @throws {CampaignValidationError} If any part is invalid.
 * @returns The same config cast as a CampaignConfig (if valid).
 */

function validateCampaignConfig<T extends CampaignConfig>(config: T): T {
  // Top-level string validations
  validateNonEmptyString(config.campaignName, 'campaignName');
  validateNonEmptyString(config.objective, 'objective');
  validateNonEmptyString(config.targetAudience, 'targetAudience');
  validateNonEmptyString(config.primaryAction, 'primaryAction');

  // Validate variants array
  if (!Array.isArray(config.variants)) {
    throw new CampaignValidationError('variants must be an array.');
  }
  if (config.variants.length === 0) {
    throw new CampaignValidationError('At least one ad variant is required.');
  }
  for (let i = 0; i < config.variants.length; i++) {
    try {
      validateAdVariant(config.variants[i]);
    } catch (err) {
      logger.error(`Validation failed for variant at index ${i}: ${(err as Error).message}`);
      throw err; // Rethrow CampaignValidationError or others
    }
  }

  // Check for duplicate variantIds
  const ids = config.variants.map(v => v.variantId);
  const duplicateIds = ids.filter((id, idx) => ids.indexOf(id) !== idx);
  if (duplicateIds.length > 0) {
    logger.warn(`Duplicate variantId(s) detected: ${[...new Set(duplicateIds)].join(', ')}. Ensure each variantId is unique.`);
  }

  logger.info(`Campaign '${config.campaignName}' validation passed.`);
  return config;
}

// ============================================================
// Campaign Definition
// ============================================================

/**
 * The main campaign object, built and validated at module load time.
 * Using `as const` for literal types and immutability.
 */

const linkedInAdCampaign = validateCampaignConfig({
  campaignName: 'Portfolio Clarity: Smart Allocation for Jamaican Investors',
  objective: 'Awareness',
  targetAudience: 'Individual investors in Jamaica (30–55, $50k–$500k JMD portfolio)',
  primaryAction: 'Educate and build trust, leading to a free downloadable guide or webinar registration',
  variants: [
    {
      variantId: 'A',
      headline: 'Stop guessing. Start allocating.',
      body: `Most investors look at P/E and dividend yield without knowing what they really mean.
A P/E of 13x might be cheap—or it might signal weak growth. A 3.7% dividend yield can be sustainable or a warning sign.

We help Jamaican investors decode these numbers and build a clear, personalised allocation plan. No jargon. Just practical, context-aware analysis.`,
      cta: {
        text: 'Download our free guide: 5 Key Metrics Every Jamaican Investor Should Know',
        url: '[Link to landing page]'
      },
      visual: {
        description: 'A clean, professional image showing a simplified stock analysis card (ticker, P/E, P/B, dividend yield, and a “our take” box) to visually reinforce the educational message.'
      }
    },
    {
      variantId: 'B',
      headline: 'Real metrics. Real allocations. Local stocks.',
      body: `Ever wondered how a toll road operator like TransJamaican Highway (TJH) can have a P/B of 6.46x and still be a smart long-term hold? Or why Seprod (SEP) trades at a P/E of 13.46x?

We break down the numbers behind Jamaican stocks—valuation, income, and qualitative factors—and show you how to allocate your capital with confidence.`,
      cta: {
        text: 'Register for our free webinar: Portfolio Clarity – A Walk Through Real Stock Analyses',
        url: '[Link to registration]'
      },
      visual: {
        description: 'A clean, professional image showing a simplified stock analysis card (ticker, P/E, P/B, dividend yield, and a “our take” box) to visually reinforce the educational message.'
      }
    }
  ] as const
} as const);

// ============================================================
// Exports
// ============================================================

export {
  CampaignValidationError,
  validateCampaignConfig,
  validateAdVariant,
  validateCTA,
  validateNonEmptyString,
  linkedInAdCampaign
};

export type {
  CampaignConfig,
  AdVariant,
  CTA,
  AdVisualDescription,
  ValidationSeverity,
  NonEmptyString
};

// ============================================================
// Usage Example (optional, for demonstration)
// ============================================================

function printAdVariant(variant: AdVariant): void {
  logger.info(`--- Variant ${variant.variantId} ---`);
  logger.info(`Headline: ${variant.headline}`);
  logger.info(`Body:\n${variant.body}`);
  logger.info(`CTA: ${variant.cta.text} (→ ${variant.cta.url})`);
  if (variant.visual) {
    logger.info(`Visual: ${variant.visual.description}`);
  }
}

// If this module is run directly, display the validated campaign.
const main = () => {
  logger.info('LinkedIn Ad Campaign Loaded Successfully');
  linkedInAdCampaign.variants.forEach(printAdVariant);
};

// Only execute main if directly invoked (not imported)
if (require.main === module) {
  main();
}