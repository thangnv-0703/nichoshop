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
    if (!payload) {
      return null;
    }

    const apiURL = this.getApiURL("paging");
    return httpClient.post(apiURL, payload);
  }
  create(payload) {
    if (!payload) {
      return null;
    }

    const apiURL = this.getApiURL();
    return httpClient.post(apiURL, payload);
  }
  update(id, payload) {
    if (!payload) {
      return null;
    }

    const apiURL = this.getApiURL(id);
    return httpClient.put(apiURL, payload);
  }
  delete(id, payload) {
    if (!id) {
      return null;
    }

    const apiURL = this.getApiURL(id);
    return httpClient.delete(apiURL);
  }

}
