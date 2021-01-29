const RequestHelper = {
    install(Vue) {

        Vue.prototype.$createRequestData = function (method, parameters) {         
                var requestData = {
                   "jsonrpc": "1.0",
                   "id":"curltest",
                   "method": method,
                   "params": parameters
                }

                return JSON.stringify(requestData);
        }
    }
}

export default RequestHelper