import { ApolloClient } from 'apollo-client'
// https://morioh.com/p/20e376ed62fb
import { createUploadLink } from 'apollo-upload-client'
import { InMemoryCache } from 'apollo-cache-inmemory'

const getToken = () => {
  const authProfile = JSON.parse(localStorage.getItem('sh-auth'))
  return authProfile ? `Bearer ${authProfile.token}` : ''
};

export default new ApolloClient({
  link: createUploadLink({ 
    uri: 'http://localhost:5000/graphql', 
    headers:  {
      authorization: getToken()
    }
  }),
  cache: new InMemoryCache({
    addTypename: false // https://stackoverflow.com/questions/47211778/cleaning-unwanted-fields-from-graphql-responses/51380645#51380645
  }),
});