angular.module('olxApp').filter('pagination', function () {
    return function (input, start) {
        start = parseInt(start, 10);

        if (!input || !input.length) { return; }
        
        return input.slice(start);
        
    };
});