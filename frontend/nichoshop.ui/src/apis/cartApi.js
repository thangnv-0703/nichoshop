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
    update(id, payload) {
        const apiURL = this.getApiURL();
        return httpClient.put(apiURL, payload);
    }
}
export default new CartApi();
