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
    updateCartItemQuantity(id, payload) {
        const apiURL = this.getApiURL('items/quantity');
        return httpClient.put(apiURL, payload);
    }
    delete(id, payload) {
        if (!id) {
            return null;
        }

        const apiURL = this.getApiURL(`items/${id}`);
        return httpClient.delete(apiURL);
    }
}
export default new CartApi();
