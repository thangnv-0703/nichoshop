import axios from "axios";
import BaseCrudApi from "./base/baseCrudApi";
class UserApi extends BaseCrudApi {
  constructor() {
    super();
    let me = this;
    me.apiVersion = "v1";
    me.controller = "user/address";
  }
}
export default new UserApi();
