/*
*   Loads the basket / shopping cart and contains all related actions specific ot it. It's used in the checkout and in the shopping cart
*/
app.controller("TodosController", ['$scope', '$http', '$timeout', 'TodoService', function ($scope, $http, $timeout, TodoService) {

    $scope.test = "hi";
    //    $scope.isLoading = false;
    //$scope.orderlines = new Array();
    //$scope.cart = new Object();
    $scope.TodoService = TodoService;
    $scope.todos = [];
    $scope.load = function () {
        $scope.refresh();
    }

    $scope.refresh = function () {
        $scope.TodoService.getTodos(undefined, '')
            .then(function (response) {
                $scope.todos = response.data;
            });
    }

    $scope.search = function () {
        $scope.TodoService.getTodos(undefined, $scope.q)
            .then(function (response) {
                $scope.todos = response.data;
                $scope.q = '';
            });
    }

    $scope.create = function () {
        $scope.TodoService.create($scope.description).then(function (response) {
            $scope.description = "";
            $scope.refresh();
        });

    }

    $scope.delete = function (todo) {
        $scope.TodoService.delete(todo).then(function (response) {
            $scope.refresh();
        });

    }

    $scope.anyCompleted = function () {
        return $scope.completedTodos.length > 0;
    }

    $scope.completedTodos = function () {
        return $scope.todos.filter(function (todo) {
            return todo.IsCompleted;
        });
    }

    $scope.changeCompletedState = function (todo, expectedCompletedState) {
        var result;

        if (expectedCompletedState) {
            result = $scope.TodoService.close(todo);
        } else {
            result = $scope.TodoService.open(todo);
        }

        result.then(function (response) {
            $scope.refresh();
        })

    }

    $scope.editable = function (todo) {
        todo.editable = true;
    }

    $scope.canEdit = function (todo) {
        return todo.editable;
    }

}]);