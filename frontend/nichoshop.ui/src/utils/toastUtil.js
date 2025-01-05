import { useToast } from "primevue/usetoast";

let toastInstance = null;

export const setToast = () => {
    toastInstance = useToast();
};

export const showToast = (options) => {
    if (toastInstance) {
        toastInstance.add(options);
    } else {
        console.error("Toast instance is not initialized. Call setToast() inside a component.");
    }
};
