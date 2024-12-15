import BaseApi from "./base/baseApi";
import httpClient from "./base/httpClient";
class LocationApi extends BaseApi {
    constructor() {
        super();
        let me = this;
        me.apiVersion = "v1";
        me.controller = "location";
    }

    getLocation(payload) {
        if (!payload) {
            return null
        }
        const apiURL = this.getApiURL();
        return httpClient.get(`${apiURL}?type=${payload.type}&parentCode=${payload.parentCode}`);
    }
}
export default new LocationApi();
