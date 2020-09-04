"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.User = void 0;
var User = /** @class */ (function () {
    function User(cliente, token) {
        this._cliente = cliente;
        this._token = token;
    }
    Object.defineProperty(User.prototype, "token", {
        get: function () {
            return this.token;
        },
        set: function (token) {
            this._token = token;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(User.prototype, "cliente", {
        get: function () {
            return this._cliente;
        },
        set: function (cliente) {
            this._cliente = cliente;
        },
        enumerable: false,
        configurable: true
    });
    return User;
}());
exports.User = User;
//# sourceMappingURL=user.model.js.map