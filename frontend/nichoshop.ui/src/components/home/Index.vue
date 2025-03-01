<template>
  <div>
    <div class="category-list-container">
      <h2 class="title">DANH MỤC</h2>
      <div class="category-grid">
        <div v-for="category in categories" :key="category.id" class="category-item">
          <img :src="`https://nichoshopstorage.blob.core.windows.net/categoryimage/${category.fileImageId}`"
            :alt="category.displayName" class="category-image" />
          <p class="category-name">{{ category.displayName }}</p>
        </div>
      </div>
    </div>
    <div class="suggestion-container">
      <h2 class="title">GỢI Ý HÔM NAY</h2>
      <div class="product-grid">
        <div v-for="(product, index) in products" :key="index" class="product-item"
          @click="goToProductDetail(product.productId)">
          <img :src="product.productImage" :alt="product.productName" class="product-image" />
          <div class="product-info">
            <p class="product-name">{{ product.productName }}</p>
            <p class="product-price">₫{{ product.amount.toLocaleString() }}</p>
            <p class="product-sold">Đã bán 69</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, getCurrentInstance, onMounted, ref } from "vue";
import { useRouter } from 'vue-router';

export default defineComponent({
  name: "Index",
  setup() {
    const { proxy } = getCurrentInstance();
    const router = useRouter();
    const categories = ref([]);
    const products = ref([]);

    const goToProductDetail = (productId) => {
      router.push({ name: 'productDetail', params: { id: productId } });
    };

    onMounted(async () => {
      // data category
      const dataCategory = await proxy.$store.dispatch("moduleCategory/getCategory");
      categories.value = dataCategory.data;

      // data product
      const dataProduct = await proxy.$store.dispatch("moduleProduct/getProductHome", {
        'pageSize': 30,
        'pageIndex': 1
      });
      products.value = dataProduct.data;
    });

    return {
      categories,
      products,
      goToProductDetail
    };
  },
});
</script>

<style lang="scss" scoped>
/* Biến SCSS */
$container-bg: #f9f9f9;
$title-color: rgba(0, 0, 0, 0.54);
$text-color: #333;
$price-color: #f53d2d;
$sold-color: #999;
$gap: 20px;
$image-size: 80px;
$product-image-size: 220px;

/* DANH MỤC */
.category-list-container {
  max-width: 1200px;
  padding: 20px;
  background-color: $container-bg;
  margin: 0 auto;

  .title {
    color: $title-color;
    font-size: 20px;
    font-weight: bold;
    margin-bottom: 20px;
  }

  .category-grid {
    display: grid;
    grid-template-columns: repeat(10, 1fr); // 10 cột mỗi hàng
    gap: $gap;

    .category-item {
      text-align: center;
      display: flex;
      flex-direction: column;
      align-items: center;

      .category-image {
        width: $image-size;
        height: $image-size;
        border-radius: 50%;
        object-fit: cover;
        margin-bottom: 10px;
      }

      .category-name {
        font-size: 14px;
        color: $text-color;
        font-weight: 500;
      }
    }
  }
}

/* GỢI Ý HÔM NAY */
.suggestion-container {
  max-width: 1200px;
  margin: 0 auto;
  background-color: $container-bg;
  padding: 20px;

  .title {
    font-size: 20px;
    font-weight: bold;
    color: $price-color;
    text-align: center;
    margin-bottom: 16px;
  }

  .product-grid {
    display: grid;
    grid-template-columns: repeat(6, 1fr); // 6 sản phẩm mỗi dòng
    gap: $gap;

    .product-item {
      cursor: pointer;
      border: 1px solid #e0e0e0;
      border-radius: 8px;
      overflow: hidden;
      background-color: #fff;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
      transition: transform 0.2s ease, box-shadow 0.2s ease;

      &:hover {
        transform: translateY(-5px);
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
      }

      .product-image {
        width: 100%;
        height: $product-image-size;
        object-fit: cover;
      }

      .product-info {
        padding: 10px;

        .product-name {
          font-size: 14px;
          color: $text-color;
          margin-bottom: 5px;
          line-height: 1.4;
        }

        .product-price {
          font-size: 16px;
          font-weight: bold;
          color: $price-color;
          margin-bottom: 5px;
        }

        .product-sold {
          font-size: 12px;
          color: $sold-color;
        }
      }
    }
  }
}
</style>
