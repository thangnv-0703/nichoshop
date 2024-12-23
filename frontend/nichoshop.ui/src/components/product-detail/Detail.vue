<template>
  <div class="detail">
    <div class="content">
      <div class="path">
        <span class="text-link">Shopee</span>
        <div class="icon-arrow-right"></div>
        <span class="text-link">Nhà Cửa & Đời Sống</span>
        <div class="icon-arrow-right"></div>
        <span class="text-link">Đồ nội thất</span>
        <div class="icon-arrow-right"></div>
        <span class="text-link">Nội thất ngoài trời</span>
        <div class="icon-arrow-right"></div>
        Ghế Công Thái Học GAMI CROM PRO
      </div>
      <div class="product">
        <div class="left">
          <div class="image-select">
            <img
              src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m2g48wamdpkk80@resize_w450_nl.webp"
              alt="hình được chọn"
            />
          </div>
          <div class="image-child">
            <img
              src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m2g48wamdpkk80@resize_w450_nl.webp"
              alt="hinh_con_1"
            />
            <img
              src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m13ts4z274hm17@resize_w450_nl.webp"
              alt="hinh_con_2"
            />
            <img
              src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m13ts4z29xmibf@resize_w450_nl.webp"
              alt="hinh_con_3"
            />
            <img
              src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m13tsorb7fcq46@resize_w450_nl.webp"
              alt="hinh_con_4"
            />
            <img
              src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m13ts4z274vva8@resize_w450_nl.webp"
              alt="hinh_con_5"
            />
          </div>
        </div>
        <div class="right">
          <span class="name">{{ product.name }}</span>
          <div class="vote">
            <span class="star">
              <span>4.9</span>
              <div class="icon-star"></div>
              <div class="icon-star"></div>
              <div class="icon-star"></div>
              <div class="icon-star"></div>
              <div class="icon-star"></div>
            </span>
            <div class="feedback">11 <span class="gray">đánh giá</span></div>
            <div class="sold">20 <span class="gray">đã bán</span></div>
          </div>
          <div class="price">
            <span class="price-new">{{ getDisplayedPrice() }}</span>
            <span class="price-old">₫7.200.000</span>
            <span class="discount">-5%</span>
          </div>
          <div class="shock-deal">
            <h3 class="title">Deal sốc</h3>
            <div class="desc">Mua Kèm Deal Sốc</div>
          </div>
          <div class="transport">
            <h3 class="title">Vận chuyển</h3>
            <div class="desc">
              <div class="line-first">
                <div class="icon-transport"></div>
                <span class="desc-transport"
                  >Nhận từ 14 Th12 - 17 Th12, phí giao</span
                >
              </div>
              <div class="line-second">
                <span class="desc-transport-2"
                  >Tặng Voucher ₫15.000 nếu đơn giao sau thời gian trên.</span
                >
              </div>
            </div>
          </div>
          <div class="insurance">
            <h3 class="title">An tâm mua sắm cùng Shopee</h3>
            <div class="desc">
              <div class="icon-protect"></div>
              <span class="text"
                >Trả hàng miễn phí 15 ngày · Bảo hiểm bảo vệ người tiêu
                dùng</span
              >
            </div>
          </div>
          <div v-for="variant in product.variants" class="attribute-first">
            <h3 class="title">{{ variant.name }}</h3>
            <div class="desc">
              <button
                v-for="option in variant.options"
                :class="{ active: isVariantSelected(variant, option) }"
                @click="selectVariant(variant, option)"
              >
                {{ option.value }}
              </button>
            </div>
          </div>

          <div class="quantity">
            <h3 class="title">Số lượng</h3>
            <div class="desc">
              <button class="decrease">-</button>
              <input type="text" value="1" />
              <button class="increase">+</button>
              <span class="inventory">94 sản phẩm có sẵn</span>
            </div>
          </div>
          <div class="button">
            <button class="add-cart">
              <div class="icon-cart"></div>
              <span>Thêm Vào Giỏ Hàng</span>
            </button>
            <button class="buy-now">
              <span>Mua Ngay</span>
            </button>
          </div>
        </div>
      </div>
      <div class="shop">
        <div class="left">
          <div class="avatar"></div>
          <div class="name">
            <span class="name-shop">Congthaihoc.vn</span>
            <span class="text-online">Online 48 phút trước</span>
            <div class="action">
              <button class="btn-shop">
                <div class="icon-chat"></div>
                <span>Chat Ngay</span>
              </button>
              <button class="btn-shop watch">
                <div class="icon-shop"></div>
                <span>Xem Shop</span>
              </button>
            </div>
          </div>
        </div>
        <div class="right">
          <div class="column">
            <div class="item-info">
              <span class="title">Đánh Giá</span>
              <span class="value">112</span>
            </div>
            <div class="item-info">
              <span class="title">Sản Phẩm</span>
              <span class="value">46</span>
            </div>
          </div>

          <div class="column">
            <div class="item-info">
              <span class="title">Tỉ Lệ Phản Hồi</span>
              <span class="value">93%</span>
            </div>
            <div class="item-info">
              <span class="title">Thời Gian Phản Hồi</span>
              <span class="value">trong vài phút</span>
            </div>
          </div>

          <div class="column">
            <div class="item-info">
              <span class="title">Tham Gia</span>
              <span class="value">6 năm trước</span>
            </div>
            <div class="item-info">
              <span class="title">Người Theo Dõi</span>
              <span class="value">919</span>
            </div>
          </div>
        </div>
      </div>
      <div class="detail">
        <div class="detail-product">
          <h2>CHI TIẾT SẢN PHẨM</h2>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, onMounted, getCurrentInstance, ref } from "vue";
import commonFunction from "../../common/commonFunction";

export default defineComponent({
  name: "Detail",
  setup() {
    const { proxy } = getCurrentInstance();
    const product = ref({});
    const selectProductVariants = ref([]);

    onMounted(async () => {
      const res = await proxy.$store.dispatch(`moduleProduct/getItem`, 1);
      if (res?.data) {
        product.value = res?.data;
        selectProductVariants.value = res?.data.variants?.map((variant) => {
          return { name: variant.name, value: variant.options[0].value };
        });
      }
    });

    const selectVariant = (variant, option) => {
      const index = selectProductVariants.value.findIndex(
        (item) => item.name == variant.name
      );
      if (index > -1) {
        selectProductVariants.value[index].value = option.value;
      } else {
        selectProductVariants.value.push({
          name: variant.name,
          value: option.value,
        });
      }
    };

    const isVariantSelected = (variant, option) => {
      return selectProductVariants.value.find(
        (item) => item.name == variant.name && option.value == item.value
      );
    };

    const getDisplayedPrice = () => {
      let foundSKU = product.value?.skus?.find((list1) => {
        return list1.skuVariants.every((item1) => {
          const item2 = selectProductVariants.value.find(
            (item) => item.name === item1.name && item.value === item1.value
          );
          return !!item2;
        });
      });
      debugger;
      return foundSKU
        ? commonFunction.getDisplayedPrice(
            foundSKU.price.amount,
            foundSKU.price.currency
          )
        : "";
      // return commonFunction.getDisplayedPrice(product.price, product.currency);
    };

    return {
      product,
      getDisplayedPrice,
      selectProductVariants,
      isVariantSelected,
      selectVariant,
    };
  },
});
</script>

<style lang="scss" scoped>
/* Biến SCSS */
$bg-full: #f5f5f5;
$bg-content: #fff;

/* DANH MỤC */
.detail {
  background-color: $bg-full;
  padding-top: 10px;
  color: #000;

  .content {
    max-width: 1200px;
    margin: 0 auto;

    .path {
      font-size: 13px;
      display: flex;
      align-items: center;
      gap: 5px;

      .text-link {
        color: #0055bb;
      }

      .icon-arrow-right {
        background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/productdetailspage/966fbe37fe1c72e3f2dd.svg);
        width: 10px;
        height: 10px;
      }
    }

    .product {
      padding: 15px;
      margin-top: 10px;
      background-color: #fff;
      border-radius: 0.125rem;
      display: flex;

      .left {
        padding-right: 15px;
        max-width: 480px;

        .image-select {
          img {
            max-width: 450px;
            max-height: 450px;
            object-fit: cover;
          }
        }

        .image-child {
          margin-top: 10px;
          display: flex;
          justify-content: space-evenly;

          img {
            width: 82px;
            height: 82px;
          }
        }
      }

      .right {
        padding: 20px 35px 0 20px;
        flex: 1;

        .name {
          font-size: 20px;
          font-weight: 500;
          line-height: 24px;
        }

        .vote {
          margin-top: 10px;
          font-size: 14px;
          display: flex;

          .star {
            display: flex;
            align-items: center;
            gap: 2px;
            padding-right: 10px;

            .icon-star {
              background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/productdetailspage/fb6d53c6a2749e183033.svg);
              width: 12px;
              height: 14px;
            }
          }

          .feedback,
          .sold {
            padding: 0 10px;
            border-left: 1px solid gray;

            .gray {
              color: #767676;
            }
          }
        }

        .price {
          margin-top: 10px;
          background: #fafafa;
          width: 100%;
          display: flex;
          align-items: center;

          .price-new {
            font-size: 30px;
            color: #ee4d2d;
          }

          .price-old {
            text-decoration: line-through;
            color: #929292;
            font-size: 16px;
            margin-left: 10px;
          }

          .discount {
            align-items: center;
            background-color: #feeeea;
            border-radius: 2px;
            color: #ee4d2d;
            display: inline-flex;
            font-size: 12px;
            font-weight: 700;
            height: 18px;
            justify-content: center;
            margin-left: 10px;
            padding: 0 4px;
          }
        }

        .shock-deal {
          margin-top: 25px;
          display: flex;
          align-items: center;

          .title {
            width: 100px;
            color: #757575;
            flex-shrink: 0;
            font-size: inherit;
            font-weight: 400;
            margin: 0 10px 0 0;
            text-transform: capitalize;
          }

          .desc {
            background-color: var(
              --brand-primary-light-color,
              rgba(255, 87, 34, 0.1)
            );
            border-radius: 2px;
            color: #ee4d2d;
            font-size: 14px;
            max-width: 450px;
            overflow: hidden;
            padding: 3px 6px;
            text-overflow: ellipsis;
            white-space: nowrap;
          }
        }

        .transport {
          margin-top: 25px;
          display: flex;

          .title {
            width: 100px;
            color: #757575;
            flex-shrink: 0;
            font-size: inherit;
            font-weight: 400;
            margin: 0 10px 0 0;
            text-transform: capitalize;
          }

          .desc {
            .line-first,
            .line-second {
              display: flex;
              align-items: center;

              .icon-transport {
                background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/productdetailspage/60e525b415f384c57249.svg);
                width: 16px;
                height: 16px;
              }

              .desc-transport,
              .desc-transport-2 {
                margin-left: 8px;
                color: #222;
                font-size: 0.875rem;
              }

              .desc-transport-2 {
                margin-left: 24px;
                color: rgba(0, 0, 0, 0.54);
                font-size: 12px;
              }
            }
          }
        }

        .insurance {
          margin-top: 25px;
          display: flex;
          align-items: center;

          .title {
            width: 100px;
            color: #757575;
            flex-shrink: 0;
            font-size: inherit;
            font-weight: 400;
            margin: 0 10px 0 0;
            text-transform: capitalize;
          }

          .desc {
            display: flex;
            gap: 8px;
            align-items: center;

            .icon-protect {
              background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/productdetailspage/e3c4dc83fbfcab7b0654.svg);
              width: 20px;
              height: 20px;
              background-position: 2px 2px;
            }

            .text {
              overflow: hidden;
              text-overflow: ellipsis;
              white-space: nowrap;
              font-size: 0.875rem;
            }
          }
        }

        .attribute-first,
        .attribute-second {
          margin-top: 25px;
          display: flex;
          align-items: center;

          .title {
            width: 100px;
            color: #757575;
            flex-shrink: 0;
            font-size: inherit;
            font-weight: 400;
            margin: 0 10px 0 0;
            text-transform: capitalize;
          }

          .desc {
            display: flex;
            align-items: center;
            gap: 8px;

            button {
              align-items: center;
              background: #fff;
              border: 1px solid rgba(0, 0, 0, 0.09);
              border-radius: 2px;
              box-sizing: border-box;
              color: rgba(0, 0, 0, 0.8);
              cursor: pointer;
              display: inline-flex;
              justify-content: center;
              min-height: 2.5rem;
              min-width: 5rem;
              outline: 0;
              overflow: visible;
              padding: 0.5rem;
              position: relative;
              text-align: left;
              word-break: break-word;
            }

            button.active {
              border-color: #ee4d2d;
              color: #ee4d2d;
            }
          }
        }

        .quantity {
          margin-top: 25px;
          display: flex;
          align-items: center;

          .title {
            width: 100px;
            color: #757575;
            flex-shrink: 0;
            font-size: inherit;
            font-weight: 400;
            margin: 0 10px 0 0;
            text-transform: capitalize;
          }

          .desc {
            display: flex;
            align-items: center;

            button {
              align-items: center;
              background: transparent;
              border: 0;
              border: 1px solid rgba(0, 0, 0, 0.09);
              border-radius: 2px;
              color: rgba(0, 0, 0, 0.8);
              cursor: pointer;
              display: flex;
              font-size: 0.875rem;
              font-weight: 300;
              height: 32px;
              justify-content: center;
              letter-spacing: 0;
              line-height: 1;
              outline: none;
              transition: background-color 0.1s cubic-bezier(0.4, 0, 0.6, 1);
              width: 32px;
            }

            input {
              background-color: #fff;
              color: #ee4d2d;
              border: 1px solid rgba(0, 0, 0, 0.09);
              border-radius: 2px;
              font-size: 0.875rem;
              height: 32px;
              width: 32px;
              text-align: center;
            }

            .inventory {
              margin-left: 15px;
              color: #757575;
              font-size: 0.875rem;
            }
          }
        }

        .button {
          margin-top: 25px;
          display: flex;
          align-items: center;
          gap: 15px;

          button.add-cart {
            display: flex;
            align-items: center;
            padding: 0 20px;
            gap: 10px;
            background-color: rgba(255, 87, 34, 0.1);
            height: 48px;
            border-radius: 2px;
            border: 1px solid #ee4d2d;
            color: #ee4d2d;

            .icon-cart {
              background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/productdetailspage/0f3bf6e431b6694a9aac.svg);
              width: 20px;
              height: 20px;
              background-size: 20px;
            }
          }

          button.buy-now {
            height: 48px;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 0 20px;
            background: #ee4d2d;
            color: #fff;
            min-width: 180px !important;
          }
        }
      }
    }

    .shop {
      margin-top: 15px;
      display: flex;
      border-radius: 0.125rem;
      background-color: #fff;
      max-height: 150px;
      height: 150px;
      padding: 10px;

      .left {
        box-sizing: border-box;
        display: flex;
        align-items: center;
        padding: 20px 25px 25px !important;
        border-right: 1px solid rgb(214, 203, 203);

        .avatar {
          background-image: url(https://down-vn.img.susercontent.com/file/vn-11134216-7ras8-m1dp2csqixco78@resize_w80_nl.webp);
          height: 80px;
          width: 80px;
          background-size: 80px;
          border-radius: 50%;
          border: 1px solid rgb(214, 203, 203);
        }

        .name {
          margin-left: 20px;
          display: flex;
          flex-direction: column;

          .name-shop {
            color: rgba(0, 0, 0, 0.87);
            font-size: 16px;
            font-weight: 500;
            margin: 0;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
          }

          .text-online {
            color: rgba(0, 0, 0, 0.54);
            font-size: 14px;
            text-transform: capitalize;
          }

          .action {
            display: flex;
            align-items: center;
            margin-top: 8px;
            gap: 10px;

            .btn-shop {
              display: flex;
              align-items: center;
              gap: 5px;
              background: rgba(255, 87, 34, 0.1);
              border: 1px solid #ee4d2d;
              box-shadow: 0 1px 1px 0 rgba(0, 0, 0, 0.03);
              color: #ee4d2d;
              outline: 0;
              overflow: visible;
              position: relative;
              height: 34px;
              max-width: 190px;
              min-width: 60px;
              padding: 0 15px;

              &.watch {
                background: #fff;
                color: #555;
                border: 1px solid rgba(0, 0, 0, 0.09);
              }

              .icon-chat {
                background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/productdetailspage/7bf03ed38ca37787fe78.svg);
                width: 16px;
                height: 16px;
              }

              .icon-shop {
                background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/productdetailspage/192a8dfc1c23525d396b.svg);
                width: 16px;
                height: 16px;
              }
            }
          }
        }
      }

      .right {
        flex: 1;
        padding-left: 25px;
        height: 150px;
        display: flex;
        justify-content: space-around;

        .column {
          display: flex;
          flex-direction: column;
          justify-content: center;
          gap: 20px;

          .item-info {
            display: flex;
            width: 100%;
            justify-content: space-between;

            .title {
              color: rgba(0, 0, 0, 0.4);
              margin-right: 12px;
              text-transform: capitalize;
              font-size: 0.875rem;
            }

            .value {
              color: #ee4d2d;
              text-align: right;
              white-space: nowrap;
              font-size: 0.875rem;
            }
          }
        }
      }
    }

    .detail {
      margin-top: 15px;
      background-color: #fff;
      padding: 15px;

      .detail-product {
        padding: 0.9375rem 0.9375rem 0;

        h2 {
          background: rgba(0, 0, 0, 0.02);
          color: rgba(0, 0, 0, 0.87);
          font-size: 1.125rem;
          font-weight: 400;
          margin: 0;
          padding: 0.875rem;
          text-transform: capitalize;
        }
      }
    }
  }
}
</style>
