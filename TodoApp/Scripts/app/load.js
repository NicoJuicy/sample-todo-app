var app = angular.module('app', []);

//https://docs.angularjs.org/guide/production
app.config(['$compileProvider', '$httpProvider', function ($compileProvider, $httpProvider) {
    $compileProvider.debugInfoEnabled(false);
    $compileProvider.commentDirectivesEnabled(false);
    $compileProvider.cssClassDirectivesEnabled(false);
    $httpProvider.interceptors.push('unauthorizedObserver');

}]);

app.factory('unauthorizedObserver', ['$q', '$window', function responseObserver($q, $window) {
    return {
        'responseError': function (errorResponse) {
            switch (errorResponse.status) {
                case 403:
                    if (errorResponse.headers().location !== undefined) {
                        $window.location = errorResponse.headers().location;
                    } else {
                        $window.location = './';
                    }

                    break;
                //case 500:
                //    $window.location = './500.html';
                //    break;
            }
            return $q.reject(errorResponse);
        }
    };
}]);



//functions
function replaceQueryParam(param, newval, search) {
    var _regex = new RegExp("([?;&])" + param + "[^&;]*[;&]?");
    var query = search.replace(_regex, "$1").replace(/&$/, '');

    return (query.length > 2 ? query + "&" : "?") + (newval ? param + "=" + newval : '');
}

function precisionRound(number, precision) {
    var factor = Math.pow(10, precision);
    return Math.round(number * factor) / factor;
}


//ProductExtensions/GetActionLink
function generateProductUrl(item, currentLanguage) {
    var url = "";
    if (item.SEO !== undefined && item.SEO.Slug.length > 0) {
        if (window.location.href.indexOf("/" + currentLanguage + "/") > -1) {
            url = "/" + currentLanguage + "/Home/Product/" + item.SEO.Slug;
        }
        else {
            url = "/Home/Product/" + item.SEO.Slug;
        }
    } else {
        if (window.location.href.indexOf("/" + currentLanguage + "/") > -1) {
            url = "/" + currentLanguage + "/Home/Index?ProductId=" + item.Id + "&full=1";
        }
        else {
            url = "/Home/Index?ProductId=" + item.Id + "&full=1";
        }
    }

    return url;
}