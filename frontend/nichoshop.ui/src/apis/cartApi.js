import httpClient from "./base/httpClient";
import BaseApi from "./base/baseApi";
class CartApi extends BaseApi {
    constructor() {
        super();
        let me = this;
        me.apiVersion = "v1";
        me.controller = "cart";
    }
    getItem() {
        const apiURL = this.getApiURL();
        return httpClient.get(apiURL);
    }
    getCheckOut() {
        const apiURL = this.getApiURL('checkout');
        return httpClient.get(apiURL);
    }
    updateCartItemQuantity(id, payload) {
        const apiURL = this.getApiURL('items/quantity');
        return httpClient.put(apiURL, payload);
    }
    updateCartItemMultiSelection(payload) {
        const apiURL = this.getApiURL('items/multi-selection');
        return httpClient.put(apiURL, payload);
    }
    delete(id, payload) {
        if (!id) {
            return null;
        }
        const apiURL = this.getApiURL(`items/${id}`);
        return httpClient.delete(apiURL);
    }
    addItemToCart(payload) {
        if (!payload) {
            return null;
        }
        const apiURL = this.getApiURL();
        return httpClient.post(apiURL, payload);
    }
}
export default new CartApi();
