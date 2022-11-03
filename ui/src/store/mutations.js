export default {
  add(state, payload) {
    state[payload.type].nodes.unshift(payload.payload)
    state[payload.type].totalCount += 1
  },
  set(state, payload) {
      state[payload.type] = payload.payload
  },
  modify(state, payload) {
    const ol = JSON.parse( JSON.stringify( state[payload.type] ) )
    var ix = ol.nodes.findIndex(i => i[payload.pk] === payload.payload[payload.pk])
    if (ix > -1) {
      ol.nodes[ix] = payload.payload
    }

    state[payload.type] = ol
  },
  remove(state, payload) {
    var ix = state[payload.type].nodes.findIndex(i => i[payload.pk] === payload.payload[payload.pk])
    if (ix > -1) {
      state[payload.type].nodes.splice(ix, 1)
      state[payload.type].totalCount -= 1
    }
  }   
}