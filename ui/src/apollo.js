import { ApolloClient } from 'apollo-client'
// https://morioh.com/p/20e376ed62fb
import { createUploadLink } from 'apollo-upload-client'
import { InMemoryCache } from 'apollo-cache-inmemory'

export default new ApolloClient({
  link: createUploadLink({ uri: 'http://localhost:5000/graphql' }),
  cache: new InMemoryCache(),
});