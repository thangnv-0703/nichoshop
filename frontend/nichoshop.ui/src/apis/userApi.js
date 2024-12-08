import axios from "axios";
import BaseApi from "./base/baseApi";
class UserApi extends BaseApi {
  constructor() {
    super();
    let me = this;
    me.apiVersion = "v1";
    me.controller = "users";
  }
  login(payload) {
    const apiURL = this.getApiURL("login");
    return axios.post(apiURL, payload);
  }
  signup(payload) {
    const apiURL = this.getApiURL("signup");
    return axios.post(apiURL, payload);
  }
}
export default new UserApi();
