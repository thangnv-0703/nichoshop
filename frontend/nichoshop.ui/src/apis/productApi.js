import httpClient from "./base/httpClient";
import BaseCrudApi from "./base/baseCrudApi";

class ProductApi extends BaseCrudApi {
    constructor() {
        super();
        let me = this;
        me.apiVersion = "v1";
        me.controller = "products";
    }

    getProductByCategory(idCategory) {
        const apiURL = this.getApiURL(`by-category/${idCategory}`);
        return httpClient.get(apiURL);
    }

    getProductHome(payload) {
        const apiURL = this.getApiURL('home');
        return httpClient.post(apiURL, payload);
    }
}
export default new ProductApi();
