
app.service('TodoService', ['$http', '$q', function ($http, $q) {

    //// this.orderlines = new Array();
    this.todos = [];

    this.getTodos = function (active, q) {
        var endPoint = "/api/todo/list?";

        if (active !== undefined) {
            endPoint += "isActive=" + active + "&";
        }

        if (q) {
            endPoint += "q=" + q + "&";
        } 

        return $http.get(endPoint);
    }

    this.create = function (description) {
        var endPoint = "api/todo/create";

        var data = JSON.stringify({ Description: description})

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

    ////search for products, standard paging included
    //this.searchProducts = function (searchTerm, page, pageSize, productId) {


    //    var endPoint = "";
    //    if (searchTerm !== undefined && searchTerm.length > 0) {
    //        endPoint = "/api/catalog/search/" + searchTerm;
    //    } else if (productId !== undefined) {
    //        endPoint = "/api/catalog/" + productId;
    //    } else {
    //        //  endPoint = "/api/catalog/";
    //    }

    //    return $http.get(endPoint);
    //};

    //this.calculateShipping = function (address, shippingMethodId) {

    //    if (address == undefined) {
    //        // return this.ShippingCost;
    //    } else {
    //        //https://appendto.com/2016/02/working-promises-angularjs-services/
    //        //var deferred = $q.defer();

    //        var endPoint = "/api/Endpoint/CalculateShippingCost?timestamp=" + Date.now();

    //        return $http({
    //            url: endPoint,
    //            method: "GET",
    //            params: {
    //                DeliveryAddress: address,
    //                ShippingMethodId: shippingMethodId,
    //                timestamp: Date.now()
    //            }
    //        });
    //    }
    //};

    //this.getCart = function (type) {
    //    var endPoint = "/api/Basket";

    //    return $http({
    //        url: endPoint,
    //        method: "GET",
    //        params: {
    //            type: type,
    //            timestamp: Date.now()
    //        }
    //    })
    //        .then(function (response) {
    //            this.cart = response.data;
    //            return this.cart;
    //        });
    //};

    //this.removeOrderLine = function (OrderLineId) {
    //    var endPoint = "/api/Basket/DeleteBasketItem";//"/api/Endpoint/RemoveOrderLine";
    //    return $http({
    //        url: endPoint,
    //        method: "DELETE",
    //        params: {
    //            Id: OrderLineId
    //        }
    //    });
    //};

    //this.addToWishList = function (ProductId) {
    //    var endPoint = "/api/Endpoint/AddToWishlist";

    //    return $http({
    //        url: endPoint + "?ProductId=" + ProductId,
    //        method: "GET"
    //    });
    //};

    //this.removeFromWishList = function (ProductId) {
    //    var endPoint = "/api/Endpoint/RemoveFromWishlist";

    //    return $http({
    //        url: endPoint + "?ProductId=" + ProductId,
    //        method: "GET"
    //    });
    //};

    //this.UpdateAmountRequest = {
    //    ProductId: "",
    //    Amount: 0,
    //    OrderLineId: "",
    //    isFixed: false
    //};

    //this.bulkUpdateAmount = function (request) {
    //    var endPoint = "/api/Endpoint/BulkAddOrderLines";
    //    return $http({
    //        url: endPoint,
    //        method: "POST",
    //        headers: {
    //            'Content-Type': "application/json"
    //        },
    //        data: request
    //    });
    //};

    //this.addCartItem = function (request) {

    //    var endPoint = "/api/Basket/AddSingleBasketItem?timestamp=" + Date.now();
    //    return $http({
    //        url: endPoint,
    //        method: "POST",
    //        headers: {
    //            'Content-Type': "application/json"
    //        },
    //        data: request
    //    });
    //};

    //this.updateAmount = function (request) {
    //    //var endPoint = "/api/Basket/ChangeBasketItemQuantity?timestamp=" + Date.now();
    //    var endPoint = "/api/Basket/ChangeBasketItemQuantity?timestamp=" + Date.now();
    //    return $http({
    //        url: endPoint,
    //        method: "POST",
    //        headers: {
    //            'Content-Type': "application/json"
    //        },
    //        data: request
    //    });
    //};


}]);