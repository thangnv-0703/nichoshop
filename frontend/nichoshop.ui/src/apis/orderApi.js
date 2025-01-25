import axios from "axios";
import BaseCrudApi from "./base/baseCrudApi";
import httpClient from "./base/httpClient";

class OrderApi extends BaseCrudApi {
  constructor() {
    super();
    let me = this;
    me.apiVersion = "v1";
    me.controller = "orders";
  }

}
export default new OrderApi();
