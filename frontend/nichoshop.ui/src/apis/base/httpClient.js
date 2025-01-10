import axios from "axios";
import { useRouter } from "vue-router";
import store from "@/stores/store";
import { showToast } from "@/utils/toastUtil";
import i18n from "../../i18n/i18n";

const { t } = i18n.global

const apiCall = async (method, apiURL, payload = null) => {
    const token = store.state.moduleUser.context?.token;
    const headers = { 'Authorization': `Bearer ${token}` };
    const router = useRouter();
    try {
        const response = await axios({
            method,
            url: apiURL,
            data: payload,
            headers
        });
        return response;
    } catch (error) {

        if (error.response.status == 401) {
            router.push("/login");
        }
        else if (error.response.status == 404 && error.response.data) {
            showToast({ severity: 'error', detail: error.response.data, group: 'tc', life: 3000, closable: false });
        }
        else if (error.response.status == 422 && error.response.data?.messageCode) {
            showToast({ severity: 'error', detail: t(error.response.data?.messageCode), group: 'tc', life: 3000, closable: false });
        }
        throw error;
    }
};

export default {
    post: (apiURL, payload) => apiCall('post', apiURL, payload),
    get: (apiURL) => apiCall('get', apiURL),
    put: (apiURL, payload) => apiCall('put', apiURL, payload),
    delete: (apiURL) => apiCall('delete', apiURL)
};