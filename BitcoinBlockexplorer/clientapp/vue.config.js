var mode = process.env.NODE_ENV || 'development';

module.exports = {
    configureWebpack: {  
        resolve: {
            alias: require('./aliases.config').webpack,
        },     
        devtool: (mode === 'development') ? 'source-map' : false,
    },
    devServer: {
        proxy: 'http://localhost:5000'
    }
};