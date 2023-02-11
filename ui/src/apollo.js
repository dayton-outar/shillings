import { ApolloClient } from 'apollo-client'
// https://morioh.com/p/20e376ed62fb
import { createUploadLink } from 'apollo-upload-client'
import { InMemoryCache } from 'apollo-cache-inmemory'

const authProfile = JSON.parse(localStorage.getItem('sh-auth')) // TODO: Need to raise an event or find event reload this. This only loads when application starts

export default new ApolloClient({
  link: createUploadLink({ 
    uri: 'http://localhost:5000/graphql', 
    headers: authProfile ? {
      authorization: `Bearer ${authProfile.token}`
    } : {}
  }),
  cache: new InMemoryCache({
    addTypename: false // https://stackoverflow.com/questions/47211778/cleaning-unwanted-fields-from-graphql-responses/51380645#51380645
  }),
});