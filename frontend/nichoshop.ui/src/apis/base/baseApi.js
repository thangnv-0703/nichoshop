export default class BaseApi {
  constructor() {
    let me = this;
  }

  getApiURL(route) {
    let me = this;
    let url = `https://localhost:44396/api/${me.apiVersion}/${me.controller}`;
    if (route) {
      url += `/${route}`;
    }
    return url;
  }
}
