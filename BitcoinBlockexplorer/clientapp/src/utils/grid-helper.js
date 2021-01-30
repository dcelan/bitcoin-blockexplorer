const GridHelper = {
    install(Vue) {

        Vue.prototype.$turnToKilo = function (value) {         
            return value/1000
        }

        Vue.prototype.$secondsToDateTime = function (seconds) {         
            var time = new Date(1970, 0, 1); //Epoch
            time.setSeconds(seconds);
            return time.toLocaleString('hr')
        }
    }
}

export default GridHelper