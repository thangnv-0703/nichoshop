import{_ as g,d as h,u as f,b as v,e as C,o,c as a,f as e,F as m,g as p,t as r,h as y,a as w}from"./index-BQF3oZCt.js";const T=h({name:"Index",setup(){const{proxy:n}=y(),s=f(),i=v([]),c=[{name:"Ghế Công Thái Học Xoay Văn Phòng CTH-27 Có Tựa Đầu Gác Chân Cao Cấp",price:112500,sold:"193",image:"https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwy239g4rzyx24_tn.webp"},{name:"Sữa Dưỡng Thể OLAY Vitamin C Bright Ultra Whitening Dưỡng Trắng Da Toàn Thân 250ml",price:9e3,sold:"5,8k",image:"https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m217ng7d6gv2d0_tn.webp"},{name:"Áo Khoác T1 4 sao màu trắng CKTG 2025",price:1e3,sold:"66,2k",image:"https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m0itpettbc7j14_tn.webp"},{name:"[FULL LINE] Reuzel Pomade tạo kiểu tóc [Blue - Pink - Red - Extreme Hold - Green - Matte Clay - Fiber] - Full size",price:95e3,sold:"3,6k",image:"https://down-vn.img.susercontent.com/file/vn-11134201-23030-rfl0jct6ilov22_tn.webp"},{name:"Áo Khoác Ralph Lauren Harrington Chất Vải Cotton Kaki Dày Mịn Form Châu Âu Oversize",price:2e3,sold:"87,4k",image:"https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m1qzq7l44csf0c_tn.webp"},{name:"Tai Nghe Nhét Tai Kz Edx Pro Edr1 Zas Ed9 Sử Dụng Tiện Lợi Chất Lượng Cao",price:2359e4,sold:"1,5k",image:"https://down-vn.img.susercontent.com/file/6c9df807556b44a6eefc2de8b5c91844_tn.webp"}],d=()=>{s.push("/product-detail")};return C(async()=>{const l=await n.$store.dispatch("moduleCategory/getCategory");i.value=await l.data}),{categories:i,products:c,goToProductDetail:d}}}),b={class:"category-list-container"},k={class:"category-grid"},$=["src","alt"],D={class:"category-name"},L={class:"suggestion-container"},N={class:"product-grid"},H=["src","alt"],I={class:"product-info"},x={class:"product-name"},P={class:"product-price"},z={class:"product-sold"};function E(n,s,i,c,d,l){return o(),a("div",null,[e("div",b,[s[1]||(s[1]=e("h2",{class:"title"},"DANH MỤC",-1)),e("div",k,[(o(!0),a(m,null,p(n.categories,t=>(o(),a("div",{key:t.id,class:"category-item"},[e("img",{src:`https://nichoshopstorage.blob.core.windows.net/categoryimage/${t.fileImageId}`,alt:t.displayName,class:"category-image"},null,8,$),e("p",D,r(t.displayName),1)]))),128))])]),e("div",L,[s[2]||(s[2]=e("h2",{class:"title"},"GỢI Ý HÔM NAY",-1)),e("div",N,[(o(!0),a(m,null,p(n.products,(t,u)=>(o(),a("div",{key:u,class:"product-item",onClick:s[0]||(s[0]=(..._)=>n.goToProductDetail&&n.goToProductDetail(..._))},[e("img",{src:t.image,alt:t.name,class:"product-image"},null,8,H),e("div",I,[e("p",x,r(t.name),1),e("p",P,"₫"+r(t.price.toLocaleString()),1),e("p",z,"Đã bán "+r(t.sold),1)])]))),128))])])])}const F=g(T,[["render",E],["__scopeId","data-v-569f58e2"]]),B={name:"Home"};function G(n,s,i,c,d,l){const t=F;return o(),a("div",null,[w(t,{style:{"margin-top":"20px"}})])}const M=g(B,[["render",G]]);export{M as default};
