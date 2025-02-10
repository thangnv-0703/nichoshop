<template>
    <div v-if="modelValue" class="overlay" @click.self="closePopup">
        <div class="popup">
            <h3 class="popup-title">Địa Chỉ Của Tôi</h3>

            <!-- Danh sách địa chỉ có scroll -->
            <div class="address-list">
                <div v-for="(address, index) in addresses" :key="index" class="address-item">
                    <label :for="'address' + index" class="address-container">
                        <input type="radio" :id="'address' + index" name="address" :value="address"
                            v-model="selectedAddress" class="radio" />
                        <div class="address-info">
                            <p class="name">
                                <strong>{{ address.name }}</strong>
                                <span class="phone"> | ({{ address.phone }})</span>
                            </p>
                            <p class="detail">{{ address.detail }}</p>
                            <div class="tags">
                                <span v-if="address.default" class="tag default">Mặc định</span>
                                <span class="tag">Địa chỉ lấy hàng</span>
                                <span class="tag">Địa chỉ trả hàng</span>
                            </div>
                        </div>
                    </label>
                    <button class="update-btn">Cập nhật</button>
                </div>
            </div>

            <!-- Footer cố định khi scroll -->
            <div class="popup-footer">
                <button class="cancel-btn" @click="closePopup">Hủy</button>
                <button class="confirm-btn" @click="confirmSelection">Xác nhận</button>
            </div>
        </div>
    </div>
</template>

<script setup>
import { defineProps, defineEmits, ref } from "vue";

// Nhận props từ component cha
const props = defineProps({
    modelValue: Boolean
});

// Gửi sự kiện để cập nhật trạng thái popup
const emit = defineEmits(["update:modelValue"]);

const selectedAddress = ref(null);
const addresses = ref([
    { name: "Lê Danh Vũ", phone: "+84 366 396 605", detail: "Nhà Nghỉ Phương Hồng, Số 38, Tôn Đức Thắng, Đồng Nai", default: true },
    { name: "Lê Danh Vũ", phone: "+84 366 396 605", detail: "Số 60, Ngõ 323 Xuân Đỉnh, Hà Nội" },
    { name: "Lê Danh Vũ", phone: "+84 366 396 605", detail: "34 Đường Bút Cương 2, Thanh Hóa" },
    { name: "Lê Danh Xuân", phone: "+84 987 921 636", detail: "Công Ty Đóng Tàu Phà Rừng, Hải Phòng" },
    { name: "Lê Danh Vũ", phone: "+84 366 396 605", detail: "Nhà Nghỉ Phương Hồng, Số 38, Tôn Đức Thắng, Đồng Nai", default: true },
    { name: "Lê Danh Vũ", phone: "+84 366 396 605", detail: "Số 60, Ngõ 323 Xuân Đỉnh, Hà Nội" },
    { name: "Lê Danh Vũ", phone: "+84 366 396 605", detail: "34 Đường Bút Cương 2, Thanh Hóa" },
    { name: "Lê Danh Xuân", phone: "+84 987 921 636", detail: "Công Ty Đóng Tàu Phà Rừng, Hải Phòng" }
]);

const closePopup = () => {
    emit("update:modelValue", false);
};

const confirmSelection = () => {
    console.log("Địa chỉ được chọn:", selectedAddress.value);
    closePopup();
};
</script>

<style lang="scss" scoped>
// Biến màu sắc
$primary-color: #ee4d2d;
$gray-color: #ddd;
$border-color: #e0e0e0;

// Overlay nền mờ
.overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.5);
    display: flex;
    align-items: center;
    justify-content: center;

    .popup {
        background: white;
        border-radius: 8px;
        width: 600px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
        padding: 20px;
        display: flex;
        flex-direction: column;

        .popup-title {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        // Danh sách địa chỉ có scroll
        .address-list {
            flex: 1;
            max-height: 500px;
            overflow-y: auto;
            padding-bottom: 10px;

            .address-item {
                display: flex;
                align-items: center;
                justify-content: space-between;
                padding: 12px;
                border-bottom: 1px solid $border-color;

                .address-container {
                    display: flex;
                    align-items: center;
                    gap: 10px;
                    flex-grow: 1;
                    cursor: pointer;

                    .radio {
                        width: 14px;
                        height: 14px;
                        accent-color: $primary-color;
                    }

                    .address-info {
                        flex-grow: 1;

                        .name {
                            font-size: 16px;
                            margin: 0;

                            .phone {
                                color: #777;
                                font-size: 14px;
                            }
                        }

                        .detail {
                            font-size: 14px;
                            color: #666;
                            margin: 5px 0;
                        }

                        .tags {
                            display: flex;
                            gap: 5px;

                            .tag {
                                font-size: 12px;
                                padding: 2px 6px;
                                border-radius: 3px;
                                background: #f5f5f5;
                                color: #666;
                            }

                            .default {
                                background: red;
                                color: white;
                            }
                        }
                    }
                }

                .update-btn {
                    background: none;
                    border: none;
                    color: blue;
                    cursor: pointer;
                    font-size: 14px;
                    padding: 0;
                }
            }
        }

        // Footer cố định khi scroll
        .popup-footer {
            position: sticky;
            bottom: 0;
            background: white;
            padding: 15px;
            display: flex;
            justify-content: flex-end;
            gap: 10px;
            border-top: 1px solid $border-color;

            .cancel-btn {
                background: $gray-color;
                color: black;
                border: none;
                padding: 10px 15px;
                border-radius: 5px;
                cursor: pointer;
            }

            .confirm-btn {
                background: $primary-color;
                color: white;
                border: none;
                padding: 10px 15px;
                border-radius: 5px;
                cursor: pointer;
            }
        }
    }
}
</style>