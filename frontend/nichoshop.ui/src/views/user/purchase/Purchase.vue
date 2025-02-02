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
          <order-card v-for="i in 2" :data="tab.data" />
        </TabPanel>
      </TabPanels>
    </Tabs>
  </div>
</template>

<script>
import { ref } from "vue";
import OrderCard from "./OrderCard.vue";
export default {
  components: {
    OrderCard,
  },
  setup() {
    const tabs = ref([
      { title: "Tất cả", data: "Tab 1 Content", value: "0" },
      { title: "Chờ thanh toán", data: "Tab 2 Content", value: "1" },
      { title: " Vận chuyển", data: "Tab 3 Content", value: "2" },
      { title: " Chờ giao hàng", data: "Tab 3 Content", value: "3" },
      { title: " Hoàn thành", data: "Tab 3 Content", value: "4" },
      { title: " Đã hủy", data: "Tab 3 Content", value: "5" },
      { title: " Trả hàng/hoàn tiền", data: "Tab 3 Content", value: "6" },
    ]);

    return { tabs };
  },
};
</script>
