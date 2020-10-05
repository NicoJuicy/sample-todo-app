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
            return !todo.IsActive;
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



    //$scope.CartItemsCount = function () {
    //    if ($scope.cart.Items === undefined || $scope.cart.Items.length === 0) return 0;

    //    return $scope.cart.Items.reduce(function (a, b) { return { Quantity: a.Quantity + b.Quantity }; }).Quantity;
    //};

    //function isPromise(value) {
    //    return Boolean(value && typeof value.then === 'function');
    //}

    ////IS NOG NIET DE LAATSTE!
    //$scope.LastAdded = function () {
    //    var undefined = new Object();

    //    if (isPromise($scope.cart)) return undefined;

    //    if ($scope.cart.Items.length > 0) {
    //        var newestOrderline = undefined;
    //        angular.forEach($scope.cart.Items, function (elem, i) {
    //            if (newestOrderline == undefined || new Date(elem.UpdatedOn) > new Date(newestOrderline.UpdatedOn)) {
    //                newestOrderline = elem;
    //            }
    //        });
    //        return newestOrderline;//$scope.orderlines[$scope.orderlines.length - 1]
    //    } else {
    //        return undefined;
    //    }
    //};

    ///** initialises the cart. 
    //* @constructor
    //* @param {boolean} loadCart - For the shopping cart. If it is true, it will reload when a product has been added to the cart.
    //**/
    //$scope.init = function (loadCart, type) {

    //    $scope.getCart(true, type);

    //    if (loadCart) {
    //        $scope.$on('BasketChanged', function (event, args) {
    //            $scope.getCart(false, type);
    //        });

    //    }
    //};

    //$scope.$on('DeleteOrderLine', function (event, args) {
    //    var indexToRemove = -1;
    //    angular.forEach($scope.cart.Items, function (elem, i) {
    //        if (elem.Id === args.OrderLineId) {
    //            indexToRemove = i;
    //        }
    //    });

    //    $scope.cart.Lines.splice(indexToRemove, 1);
    //});

    //$scope.$on('ChangeOrderLine', function (event, args) {
    //    angular.forEach($scope.cart.Items, function (elem, i) {

    //        if (args.OrderLine.Id === elem.Id) {
    //            elem.Price = args.OrderLine.Price;
    //            elem.OldPrice = args.OrderLine.OldPrice;
    //            elem.Quantity = args.OrderLine.Quantity;
    //        }
    //    });
    //});

    //$scope.getItems = function () {
    //    var cnt = 0;

    //    if (Object.prototype.toString.call($scope.cart.Items) === '[object Array]') {
    //        angular.forEach($scope.cart.Items, function (elem, i) {
    //            cnt += parseFloat(elem.Quantity);
    //        });
    //    }

    //    return cnt;
    //};



    //$scope.getCart = function (init, type) {
    //    if (!init) {
    //        $scope.cart = EndpointService.cart;
    //    } else {
    //        $scope.cart = EndpointService.getCart(type).then(function (response) {
    //            $scope.cart = response;
    //        });
    //    }
    //};


}]);