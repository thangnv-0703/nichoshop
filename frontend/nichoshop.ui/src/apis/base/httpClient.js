import axios from "axios";
export default {
    post: (apiURL, payload) => {
        const token = localStorage.getItem('token')
        const headers = { 'Authorization': `Bearer ${token}` };
        return axios.post(apiURL, payload, { headers });
    },
    get: (apiURL) => {
        const token = localStorage.getItem('token')
        const headers = { 'Authorization': `Bearer ${token}` };
        return axios.get(apiURL, { headers });
    },
    put: (apiURL, payload) => {
        const token = localStorage.getItem('token')
        const headers = { 'Authorization': `Bearer ${token}` };
        return axios.put(apiURL, payload, { headers });
    },
    delete: (apiURL) => {
        const token = localStorage.getItem('token')
        const headers = { 'Authorization': `Bearer ${token}` };
        return axios.delete(apiURL, { headers });
    },
}