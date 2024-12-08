import httpClient from "./base/httpClient";
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
    return httpClient.post(apiURL, payload);
  }
  signup(payload) {
    const apiURL = this.getApiURL("signup");
    return httpClient.post(apiURL, payload);
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
export default new UserApi();
