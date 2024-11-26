<template>
  <div>
    <div class="category-list-container">
      <h2 class="title">DANH MỤC</h2>
      <div class="category-grid">
        <div
          v-for="(category, index) in categories"
          :key="index"
          class="category-item"
        >
          <img
            src="@/assets/images/bachhoa.png"
            :alt="category.name"
            class="category-image"
          />
          <p class="category-name">{{ category.name }}</p>
        </div>
      </div>
    </div>
    <div class="suggestion-container">
      <h2 class="title">GỢI Ý HÔM NAY</h2>
      <div class="product-grid">
        <div
          v-for="(product, index) in products"
          :key="index"
          class="product-item"
        >
          <img
            src="@/assets/images/samsung.webp"
            :alt="product.name"
            class="product-image"
          />
          <div class="product-info">
            <p class="product-name">{{ product.name }}</p>
            <p class="product-price">₫{{ product.price.toLocaleString() }}</p>
            <p class="product-sold">Đã bán {{ product.sold }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";

export default defineComponent({
  name: "Index",
  setup() {
    const categories = [
      { name: "Thời Trang Nam", image: "samsung.webp" },
      { name: "Thời Trang Nữ", image: "thoitrangnu.png" },
      { name: "Mẹ & Bé", image: "mevabe.png" },
      { name: "Nhà Cửa & Đời Sống", image: "nhacua.png" },
      { name: "Sắc Đẹp", image: "sacdep.png" },
      { name: "Sức Khỏe", image: "suckhoe.png" },
      { name: "Giày Dép Nữ", image: "giaydepnu.png" },
      { name: "Túi Ví Nữ", image: "tuivinu.png" },
      { name: "Phụ Kiện & Trang Sức Nữ", image: "trangsuc.png" },
      { name: "Bách Hóa Online", image: "bachhoa.png" },
      { name: "Nhà Sách Online", image: "nhasach.png" },
      { name: "Điện Thoại & Phụ Kiện", image: "dienthoai.png" },
      { name: "Thiết Bị Điện Tử", image: "thietbidientu.png" },
      { name: "Máy Tính & Laptop", image: "maytinh.png" },
      { name: "Máy Ảnh & Máy Quay Phim", image: "mayanh.png" },
      { name: "Đồng Hồ", image: "dongho.png" },
      { name: "Giày Dép Nam", image: "giaydepnam.png" },
      { name: "Thiết Bị Điện Gia Dụng", image: "diengiadung.png" },
      { name: "Thể Thao & Du Lịch", image: "thethao.png" },
      { name: "Ô Tô & Xe Máy & Xe Đạp", image: "otomayxe.png" },
    ];

    const products = [
      {
        name: "Hạt Điều Rang Cùi Túi",
        price: 112500,
        sold: "193",
        image: "hatdieu.png",
      },
      {
        name: "Dép Cặp Quai Nút",
        price: 9000,
        sold: "5,8k",
        image: "depquainut.png",
      },
      {
        name: "Áo Thun Nam Tay Lỡ",
        price: 1000,
        sold: "66,2k",
        image: "aothun.png",
      },
      {
        name: "Áo Khoác Bố Rêu",
        price: 95000,
        sold: "3,6k",
        image: "aokhoac.png",
      },
      {
        name: "Kẹp Tóc BB Mini",
        price: 2000,
        sold: "87,4k",
        image: "keptoc.png",
      },
      {
        name: "Điện Thoại Samsung",
        price: 23590000,
        sold: "1,5k",
        image: "samsung.png",
      },
    ];

    return {
      categories,
      products,
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
