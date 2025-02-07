<template>
  <div class="flex justify-between items-center">
    <div class="flex items-center gap-3 mb-4">
      <div>
        <svg width="17" height="16" viewBox="0 0 17 16">
          <path
            d="M1.95 6.6c.156.804.7 1.867 1.357 1.867.654 0 1.43 0 1.43-.933h.932s0 .933 1.155.933c1.176 0 1.15-.933 1.15-.933h.984s-.027.933 1.148.933c1.157 0 1.15-.933 1.15-.933h.94s0 .933 1.43.933c1.368 0 1.356-1.867 1.356-1.867H1.95zm11.49-4.666H3.493L2.248 5.667h12.437L13.44 1.934zM2.853 14.066h11.22l-.01-4.782c-.148.02-.295.042-.465.042-.7 0-1.436-.324-1.866-.86-.376.53-.88.86-1.622.86-.667 0-1.255-.417-1.64-.86-.39.443-.976.86-1.643.86-.74 0-1.246-.33-1.623-.86-.43.536-1.195.86-1.895.86-.152 0-.297-.02-.436-.05l-.018 4.79zM14.996 12.2v.933L14.984 15H1.94l-.002-1.867V8.84C1.355 8.306 1.003 7.456 1 6.6L2.87 1h11.193l1.866 5.6c0 .943-.225 1.876-.934 2.39v3.21z"
            stroke-width=".3"
            stroke="#333"
            fill="#333"
            fill-rule="evenodd"
          ></path>
        </svg>
      </div>
      <span><b>Linh kiện điện tử 720</b></span>
      <div class="button-secondary button button-sm">
        <svg
          enable-background="new 0 0 15 15"
          viewBox="0 0 15 15"
          x="0"
          y="0"
          class="nicho-svg-icon icon-btn-shop"
        >
          <path
            d="m15 4.8c-.1-1-.8-2-1.6-2.9-.4-.3-.7-.5-1-.8-.1-.1-.7-.5-.7-.5h-8.5s-1.4 1.4-1.6 1.6c-.4.4-.8 1-1.1 1.4-.1.4-.4.8-.4 1.1-.3 1.4 0 2.3.6 3.3l.3.3v3.5c0 1.5 1.1 2.6 2.6 2.6h8c1.5 0 2.5-1.1 2.5-2.6v-3.7c.1-.1.1-.3.3-.3.4-.8.7-1.7.6-3zm-3 7c0 .4-.1.5-.4.5h-8c-.3 0-.5-.1-.5-.5v-3.1c.3 0 .5-.1.8-.4.1 0 .3-.1.3-.1.4.4 1 .7 1.5.7.7 0 1.2-.1 1.6-.5.5.3 1.1.4 1.6.4.7 0 1.2-.3 1.8-.7.1.1.3.3.5.4.3.1.5.3.8.3zm.5-5.2c0 .1-.4.7-.3.5l-.1.1c-.1 0-.3 0-.4-.1s-.3-.3-.5-.5l-.5-1.1-.5 1.1c-.4.4-.8.7-1.4.7-.5 0-.7 0-1-.5l-.6-1.1-.5 1.1c-.3.5-.6.6-1.1.6-.3 0-.6-.2-.9-.8l-.5-1-.7 1c-.1.3-.3.4-.4.6-.1 0-.3.1-.3.1s-.4-.4-.4-.5c-.4-.5-.5-.9-.4-1.5 0-.1.1-.4.3-.5.3-.5.4-.8.8-1.2.7-.8.8-1 1-1h7s .3.1.8.7c.5.5 1.1 1.2 1.1 1.8-.1.7-.2 1.2-.5 1.5z"
          ></path>
        </svg>
        <button class="ml-1">Xem Shop</button>
      </div>
    </div>
    <div class="text-[#ee4d2d] text-[14px]">HOÀN THÀNH</div>
  </div>
  <div v-for="i in 3" :key="i" class="order-item">
    <div class="flex gap-3 items-center justify-between">
      <div class="flex gap-3 items-center">
        <img
          class="order-item-image"
          src="https://down-vn.img.susercontent.com/file/sg-11134201-7rbmg-lllmadf4luzh25_tn"
          alt=""
        />
        <div>
          <span>
            Dây cắm test board 10cm/21cm/30cm lõi đồng, mối tiếp xúc tốt và chắc
            chắn, kết nối siêu nhanh (10 sợi)</span
          >
          <p class="text-[#929292]">Phân loại hàng: 10cm</p>
          <p>x1</p>
        </div>
      </div>
      <div class="order-item-price">
        <span class="text-[#929292] line-through text-[14px] mr-1">
          ₫544.450
        </span>
        <span class="text-[#ee4d2d] text-[14px]"> ₫269.450 </span>
      </div>
    </div>
  </div>
  <div class="flex justify-end items-center mb-10">
    <div>
      <div class="text-end footer-price-content">
        Thành tiền: <span class="text-[#ee4d2d] footer-price">₫269.450</span>
      </div>
      <button class="button-primary button mr-3">Mua lại</button>
      <button class="button-secondary button">Xem đánh giá người mua</button>
    </div>
  </div>
</template>

<script>
import { ref, onMounted, getCurrentInstance } from "vue";

export default {
  props: {
    data: {
      type: Object,
      default: () => ({}),
    },
  },
  setup(props) {
    onMounted(() => {
      console.log(props.data);
    });
  },
};
</script>

<style>
.order-item-image {
  height: 80px;
  width: 80px;
}
.order-item-price {
  display: flex;
}
.footer-price-content {
  padding: 24px 0 12px 24px;
}
.footer-price {
  font-size: 24px;
  line-height: 30px;
}
</style>
