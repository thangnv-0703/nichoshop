<template>
  <div class="card">
    <Tabs value="0">
      <TabList>
        <Tab v-for="tab in tabs" :key="tab.title" :value="tab.value">{{
          tab.title
        }}</Tab>
      </TabList>
      <TabPanels>
        <TabPanel v-for="tab in tabs" :key="tab.value" :value="tab.value">
          <order-card v-for="item in items" :data="item" />
        </TabPanel>
      </TabPanels>
    </Tabs>
  </div>
</template>

<script>
import OrderCard from "./OrderCard.vue";
import { ref, onMounted, getCurrentInstance } from "vue";
import baseList from "@/views/base/baseList.js";
export default {
  extends: baseList,

  components: {
    OrderCard,
  },
  setup() {
    const autoLoadGrid = true;
    const { proxy } = getCurrentInstance();
    const module = "moduleOrder";
    const tabs = ref([
      { title: "Tất cả", data: "Tab 1 Content", value: "0" },
      { title: "Chờ thanh toán", data: "Tab 2 Content", value: "1" },
      { title: " Vận chuyển", data: "Tab 3 Content", value: "2" },
      { title: " Chờ giao hàng", data: "Tab 3 Content", value: "3" },
      { title: " Hoàn thành", data: "Tab 3 Content", value: "4" },
      { title: " Đã hủy", data: "Tab 3 Content", value: "5" },
      { title: " Trả hàng/hoàn tiền", data: "Tab 3 Content", value: "6" },
    ]);

    return { module, autoLoadGrid, tabs };
  },
};
</script>
