import httpClient from "./httpClient";
import BaseApi from "./baseApi";
export default class BaseCrudApi extends BaseApi {
  constructor() {
    super();
  }
  getAll() {
    const apiURL = this.getApiURL();
    return httpClient.get(apiURL);
  }
  getPaging(payload) {
    const apiURL = this.getApiURL("paging");
    return httpClient.post(apiURL, payload);
  }
  create(payload) {
    const apiURL = this.getApiURL();
    return httpClient.post(apiURL, payload);
  }
  update(id, payload) {
    const apiURL = this.getApiURL(id);
    return httpClient.put(apiURL, payload);
  }

}
