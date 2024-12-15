<template>
  <div>
    <div class="category-list-container">
      <h2 class="title">DANH MỤC</h2>
      <div class="category-grid">
        <div v-for="(category, index) in categories" :key="index" class="category-item">
          <img :src="category.image" :alt="category.name" class="category-image" />
          <p class="category-name">{{ category.name }}</p>
        </div>
      </div>
    </div>
    <div class="suggestion-container">
      <h2 class="title">GỢI Ý HÔM NAY</h2>
      <div class="product-grid">
        <div v-for="(product, index) in products" :key="index" class="product-item" @click="goToProductDetail">
          <img :src="product.image" :alt="product.name" class="product-image" />
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
import { useRouter } from 'vue-router';

export default defineComponent({
  name: "Index",
  setup() {
    const router = useRouter();

    const categories = [
      { name: "Thời Trang Nam", image: "https://down-vn.img.susercontent.com/file/687f3967b7c2fe6a134a2c11894eea4b@resize_w320_nl.webp" },
      { name: "Điện Thoại & Phụ Kiện", image: "https://down-vn.img.susercontent.com/file/31234a27876fb89cd522d7e3db1ba5ca@resize_w320_nl.webp" },
      { name: "Thiết Bị Điện Tử", image: "https://down-vn.img.susercontent.com/file/978b9e4cb61c611aaaf58664fae133c5@resize_w320_nl.webp" },
      { name: "Máy Tính & Laptop", image: "https://down-vn.img.susercontent.com/file/c3f3edfaa9f6dafc4825b77d8449999d@resize_w320_nl.webp" },
      { name: "Máy Ảnh & Máy Quay Phim", image: "https://down-vn.img.susercontent.com/file/ec14dd4fc238e676e43be2a911414d4d@resize_w320_nl.webp" },
      { name: "Đồng Hồ", image: "https://down-vn.img.susercontent.com/file/86c294aae72ca1db5f541790f7796260@resize_w320_nl.webp" },
      { name: "Giày Dép Nam", image: "https://down-vn.img.susercontent.com/file/74ca517e1fa74dc4d974e5d03c3139de@resize_w320_nl.webp" },
      { name: "Thiết Bị Điện Gia Dụng", image: "https://down-vn.img.susercontent.com/file/7abfbfee3c4844652b4a8245e473d857@resize_w320_nl.webp" },
      { name: "Thể Thao & Du Lịch", image: "https://down-vn.img.susercontent.com/file/6cb7e633f8b63757463b676bd19a50e4@resize_w320_nl.webp" },
      { name: "Ô Tô & Xe Máy & Xe Đạp", image: "https://down-vn.img.susercontent.com/file/3fb459e3449905545701b418e8220334@resize_w320_nl.webp" },
      { name: "Thời Trang Nữ", image: "https://down-vn.img.susercontent.com/file/75ea42f9eca124e9cb3cde744c060e4d@resize_w320_nl.webp" },
      { name: "Mẹ & Bé", image: "https://down-vn.img.susercontent.com/file/099edde1ab31df35bc255912bab54a5e@resize_w320_nl.webp" },
      { name: "Nhà Cửa & Đời Sống", image: "https://down-vn.img.susercontent.com/file/24b194a695ea59d384768b7b471d563f@resize_w320_nl.webp" },
      { name: "Sắc Đẹp", image: "https://down-vn.img.susercontent.com/file/ef1f336ecc6f97b790d5aae9916dcb72@resize_w320_nl.webp" },
      { name: "Sức Khỏe", image: "https://down-vn.img.susercontent.com/file/49119e891a44fa135f5f6f5fd4cfc747@resize_w320_nl.webp" },
      { name: "Giày Dép Nữ", image: "https://down-vn.img.susercontent.com/file/48630b7c76a7b62bc070c9e227097847@resize_w320_nl.webp" },
      { name: "Túi Ví Nữ", image: "https://down-vn.img.susercontent.com/file/fa6ada2555e8e51f369718bbc92ccc52@resize_w320_nl.webp" },
      { name: "Phụ Kiện & Trang Sức Nữ", image: "https://down-vn.img.susercontent.com/file/8e71245b9659ea72c1b4e737be5cf42e@resize_w320_nl.webp" },
      { name: "Bách Hóa Online", image: "https://down-vn.img.susercontent.com/file/c432168ee788f903f1ea024487f2c889@resize_w320_nl.webp" },
      { name: "Nhà Sách Online", image: "https://down-vn.img.susercontent.com/file/36013311815c55d303b0e6c62d6a8139@resize_w320_nl.webp" },
    ];

    const products = [
      {
        name: "Ghế Công Thái Học Xoay Văn Phòng CTH-27 Có Tựa Đầu Gác Chân Cao Cấp",
        price: 112500,
        sold: "193",
        image: "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwy239g4rzyx24_tn.webp",
      },
      {
        name: "Sữa Dưỡng Thể OLAY Vitamin C Bright Ultra Whitening Dưỡng Trắng Da Toàn Thân 250ml",
        price: 9000,
        sold: "5,8k",
        image: "https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m217ng7d6gv2d0_tn.webp",
      },
      {
        name: "Áo Khoác T1 4 sao màu trắng CKTG 2025",
        price: 1000,
        sold: "66,2k",
        image: "https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m0itpettbc7j14_tn.webp",
      },
      {
        name: "[FULL LINE] Reuzel Pomade tạo kiểu tóc [Blue - Pink - Red - Extreme Hold - Green - Matte Clay - Fiber] - Full size",
        price: 95000,
        sold: "3,6k",
        image: "https://down-vn.img.susercontent.com/file/vn-11134201-23030-rfl0jct6ilov22_tn.webp",
      },
      {
        name: "Áo Khoác Ralph Lauren Harrington Chất Vải Cotton Kaki Dày Mịn Form Châu Âu Oversize",
        price: 2000,
        sold: "87,4k",
        image: "https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m1qzq7l44csf0c_tn.webp",
      },
      {
        name: "Tai Nghe Nhét Tai Kz Edx Pro Edr1 Zas Ed9 Sử Dụng Tiện Lợi Chất Lượng Cao",
        price: 23590000,
        sold: "1,5k",
        image: "https://down-vn.img.susercontent.com/file/6c9df807556b44a6eefc2de8b5c91844_tn.webp",
      },
    ];

    const goToProductDetail = () => {
      router.push('/product-detail');
    };

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
