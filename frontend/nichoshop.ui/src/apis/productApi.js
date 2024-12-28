import BaseCrudApi from "./base/baseCrudApi";
class ProductApi extends BaseCrudApi {
    constructor() {
        super();
        let me = this;
        me.apiVersion = "v1";
        me.controller = "products";
    }
}
export default new ProductApi();
