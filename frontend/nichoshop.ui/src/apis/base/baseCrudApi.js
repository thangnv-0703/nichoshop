import axios from "axios";
import BaseApi from "./baseApi";
export default class BaseCrudApi extends BaseApi {
  constructor() {
    super();
  }
  getPaging(payload) {
    const apiURL = this.getApiURL("paging");
    return axios.post(apiURL, payload);
  }
}
