"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ECommerceService = void 0;
var category_enum_1 = require("../models/category.enum");
var ECommerceService = /** @class */ (function () {
    function ECommerceService() {
        this.products = [
            { id: 1, name: "Laptop", price: 45000, stock: 3, category: category_enum_1.Category.Electronics },
            { id: 2, name: "Jeans", price: 1500, stock: 10, category: category_enum_1.Category.Clothing },
            { id: 3, name: "Rice Bag", price: 700, stock: 5, category: category_enum_1.Category.Grocery }
        ];
        this.cart = [];
    }
    ECommerceService.prototype.viewProducts = function () {
        console.log("Available Products:");
        for (var _i = 0, _a = this.products; _i < _a.length; _i++) {
            var p = _a[_i];
            console.log("".concat(p.name, " | \u20B9").concat(p.price, " | In Stock: ").concat(p.stock, " | Category: ").concat(p.category));
        }
        console.log();
    };
    ECommerceService.prototype.addToCart = function (productId, quantity) {
        var product = this.products.find(function (p) { return p.id === productId; });
        if (!product) {
            console.log("Product not found.");
            return;
        }
        if (product.stock < quantity) {
            console.log("Not enough stock for ".concat(product.name, "."));
            return;
        }
        var existingItem = this.cart.find(function (ci) { return ci.product.id === productId; });
        if (existingItem) {
            existingItem.quantity += quantity;
        }
        else {
            this.cart.push({ product: product, quantity: quantity });
        }
        product.stock -= quantity;
        console.log("".concat(quantity, " x ").concat(product.name, " added to cart.\n"));
    };
    ECommerceService.prototype.removeFromCart = function (productId) {
        var index = this.cart.findIndex(function (ci) { return ci.product.id === productId; });
        if (index === -1) {
            console.log("Product not in cart.");
            return;
        }
        var item = this.cart[index];
        item.product.stock += item.quantity;
        this.cart.splice(index, 1);
        console.log("".concat(item.product.name, " removed from cart.\n"));
    };
    ECommerceService.prototype.showCartSummary = function () {
        console.log("Cart Summary:");
        var total = 0;
        for (var _i = 0, _a = this.cart; _i < _a.length; _i++) {
            var item = _a[_i];
            var subtotal = item.product.price * item.quantity;
            total += subtotal;
            console.log("".concat(item.product.name, " - \u20B9").concat(item.product.price, " x ").concat(item.quantity));
        }
        console.log("Total: \u20B9".concat(total));
        var discountedTotal = total;
        if (total >= 10000) {
            discountedTotal *= 0.85;
        }
        else if (total >= 5000) {
            discountedTotal *= 0.90;
        }
        if (discountedTotal !== total) {
            console.log("Discounted Total: \u20B9".concat(Math.round(discountedTotal), "\n"));
        }
        else {
            console.log("No discount applied.\n");
        }
    };
    return ECommerceService;
}());
exports.ECommerceService = ECommerceService;
