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
            return time.toLocaleString('hr-HR')
        }    

        Vue.prototype.$copyToClipboard = function (data) {         
            navigator.clipboard.writeText(data)
                .then(()=> {                    
                    this.$bvToast.toast("Copying to clipboard successful",
                        { title: "Success", variant: "info", solid: true, autoHideDelay:500 })
                }, function(err) {
                    console.error('Async: Could not copy to clipboard: ', err);
                });
        }       

        Vue.prototype.$scrollToTop = function () {         
            document.documentElement.scrollTop = 0;
        }   
    }
}

export default GridHelper