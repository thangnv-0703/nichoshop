import axios from "axios";
import BaseCrudApi from "./base/baseCrudApi";
import httpClient from "./base/httpClient";

class UserApi extends BaseCrudApi {
  constructor() {
    super();
    let me = this;
    me.apiVersion = "v1";
    me.controller = "users/address";
  }
  setAsDefault(id) {
    const apiURL = this.getApiURL(`${id}/default`);
    return httpClient.put(apiURL);
  }
}
export default new UserApi();
