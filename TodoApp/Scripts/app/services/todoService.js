
app.service('TodoService', ['$http', '$q', function ($http, $q) {

    //// this.orderlines = new Array();
    this.todos = [];

    this.getTodos = function (completed, q) {
        var endPoint = "/api/todo/list?";

        if (completed !== undefined) {
            endPoint += "isCompleted=" + completed + "&";
        }

        if (q) {
            endPoint += "q=" + q + "&";
        }

        return $http.get(endPoint);
    }

    this.create = function (description) {
        var endPoint = "api/todo/create";

        var data = JSON.stringify({ Description: description })

        return $http.post(endPoint, data);
    }

    this.delete = function (todo) {
        var endPoint = "/api/todo/delete?id=" + todo.Id;
        return $http.delete(endPoint);
    }

    this.close = function (todo) {
        var endPoint = "/api/todo/close?id=" + todo.Id;
        return $http.put(endPoint);
    }

    this.open = function (todo) {

        var endPoint = "/api/todo/open?id=" + todo.Id;
        return $http.put(endPoint);
    }

}]);