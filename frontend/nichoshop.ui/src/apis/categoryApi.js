import BaseCrudApi from "./base/baseCrudApi";
class CategoryApi extends BaseCrudApi {
    constructor() {
        super();
        let me = this;
        me.apiVersion = "v1";
        me.controller = "categories";
    }
}
export default new CategoryApi();
