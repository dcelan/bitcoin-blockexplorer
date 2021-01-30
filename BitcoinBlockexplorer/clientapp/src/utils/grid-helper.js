const GridHelper = {
    install(Vue) {

        Vue.prototype.$turnToKilo = function (value) {         
            return value/1000
        }

        Vue.prototype.$satoshiToBTC = function (value) {         
            return value/100000000
        }

        Vue.prototype.$secondsToDateTime = function (seconds) {         
            var time = new Date(1970, 0, 1); //Epoch
            time.setSeconds(seconds);
            return time.toLocaleString('en-GB')
        }    

        Vue.prototype.$copyToClipboard = function (data) {         
            navigator.clipboard.writeText(data)
                .then(function() {                    
                    console.log('Async: Copying to clipboard successful');
                }, function(err) {
                    console.error('Async: Could not copy to clipboard: ', err);
                });
        }        
    }
}

export default GridHelper