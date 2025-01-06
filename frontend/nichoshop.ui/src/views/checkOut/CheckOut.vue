<template>
    <div class="contentCheckout">
        <Header :isCheckOut="true"></Header>
        <div class="checkout">
            <div class="content-address">
                <div class="line"></div>
                <div class="address">
                    <div class="title">
                        <svg style="color: #ee4d2d; fill: currentColor;" height="16" viewBox="0 0 12 16" width="12"
                            class="shopee-svg-icon icon-location-marker">
                            <path
                                d="M6 3.2c1.506 0 2.727 1.195 2.727 2.667 0 1.473-1.22 2.666-2.727 2.666S3.273 7.34 3.273 5.867C3.273 4.395 4.493 3.2 6 3.2zM0 6c0-3.315 2.686-6 6-6s6 2.685 6 6c0 2.498-1.964 5.742-6 9.933C1.613 11.743 0 8.498 0 6z"
                                fill-rule="evenodd"></path>
                        </svg>
                        <h2>Địa chỉ nhận hàng</h2>
                    </div>
                    <div class="desc">
                        <span class="name phonenumber">
                            Lê Danh Vũ (+84) 366396605
                        </span>
                        <span class="address-desc">Số 60, Ngõ 323 Xuân Đỉnh, Phường Xuân Đỉnh, Quận Bắc Từ Liêm, Hà
                            Nội</span>
                        <span class="default">Mặc Định</span>
                        <span class="change">Thay Đổi</span>
                    </div>
                </div>
            </div>
            <div class="content-product">
                <div class="title">
                    <span class="product">Sản phẩm</span>
                    <span class="amount">Đơn giá</span>
                    <span class="quantity">Số lượng</span>
                    <span class="price">Thành tiền</span>
                </div>
                <div class="detail">
                    <div class="shop">
                        <div class="shopee_mall">
                            <svg viewBox="0 0 24 11">
                                <title>Mall</title>
                                <g fill="#fff" fill-rule="evenodd">
                                    <path
                                        d="M19.615 7.143V1.805a.805.805 0 0 0-1.611 0v5.377H18c0 1.438.634 2.36 1.902 2.77V9.95c.09.032.19.05.293.05.444 0 .805-.334.805-.746a.748.748 0 0 0-.498-.69v-.002c-.59-.22-.885-.694-.885-1.42h-.002zm3 0V1.805a.805.805 0 0 0-1.611 0v5.377H21c0 1.438.634 2.36 1.902 2.77V9.95c.09.032.19.05.293.05.444 0 .805-.334.805-.746a.748.748 0 0 0-.498-.69v-.002c-.59-.22-.885-.694-.885-1.42h-.002zm-7.491-2.985c.01-.366.37-.726.813-.726.45 0 .814.37.814.742v5.058c0 .37-.364.73-.813.73-.395 0-.725-.278-.798-.598a3.166 3.166 0 0 1-1.964.68c-1.77 0-3.268-1.456-3.268-3.254 0-1.797 1.497-3.328 3.268-3.328a3.1 3.1 0 0 1 1.948.696zm-.146 2.594a1.8 1.8 0 1 0-3.6 0 1.8 1.8 0 1 0 3.6 0z">
                                    </path>
                                    <path
                                        d="M.078 1.563A.733.733 0 0 1 .565.89c.423-.15.832.16 1.008.52.512 1.056 1.57 1.88 2.99 1.9s2.158-.85 2.71-1.882c.19-.356.626-.74 1.13-.537.342.138.477.4.472.65a.68.68 0 0 1 .004.08v7.63a.75.75 0 0 1-1.5 0V3.67c-.763.72-1.677 1.18-2.842 1.16a4.856 4.856 0 0 1-2.965-1.096V9.25a.75.75 0 0 1-1.5 0V1.648c0-.03.002-.057.005-.085z"
                                        fill-rule="nonzero"></path>
                                </g>
                            </svg>
                        </div>
                        <span class="nameshop">Cocoon Vietnam Chính Hãng</span>
                        <svg style="width: 20px; height: 15px; color: #00bfa5; fill: currentColor;" viewBox="0 0 16 16"
                            class="shopee-svg-icon FpgzUK">
                            <g fill-rule="evenodd">
                                <path
                                    d="M15 4a1 1 0 01.993.883L16 5v9.932a.5.5 0 01-.82.385l-2.061-1.718-8.199.001a1 1 0 01-.98-.8l-.016-.117-.108-1.284 8.058.001a2 2 0 001.976-1.692l.018-.155L14.293 4H15zm-2.48-4a1 1 0 011 1l-.003.077-.646 8.4a1 1 0 01-.997.923l-8.994-.001-2.06 1.718a.5.5 0 01-.233.108l-.087.007a.5.5 0 01-.492-.41L0 11.732V1a1 1 0 011-1h11.52zM3.646 4.246a.5.5 0 000 .708c.305.304.694.526 1.146.682A4.936 4.936 0 006.4 5.9c.464 0 1.02-.062 1.608-.264.452-.156.841-.378 1.146-.682a.5.5 0 10-.708-.708c-.185.186-.445.335-.764.444a4.004 4.004 0 01-2.564 0c-.319-.11-.579-.258-.764-.444a.5.5 0 00-.708 0z">
                                </path>
                            </g>
                        </svg>
                        <span class="chat">Chat ngay</span>
                    </div>
                    <div class="product">
                        <img src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m4k9lc59h3v355@resize_w80_nl.webp"
                            alt="" class="image">
                        <span class="name-product">Tinh chất bí đao (serum) 7% Niacinamide sạch mụn chuyên sâu & mờ vết
                            thâm Cocoon 70ml</span>
                        <span class="amount">₫295.000</span>
                        <span class="quantity">2</span>
                        <span class="price">₫590.000</span>
                    </div>
                    <div class="vouncher">
                        <div class="empty"></div>
                        <div class="vouncher-content">
                            <svg fill="none" viewBox="0 -2 23 22" class="shopee-svg-icon icon-voucher-line">
                                <g filter="url(#voucher-filter0_d)">
                                    <mask id="a" fill="#fff">
                                        <path fill-rule="evenodd" clip-rule="evenodd"
                                            d="M1 2h18v2.32a1.5 1.5 0 000 2.75v.65a1.5 1.5 0 000 2.75v.65a1.5 1.5 0 000 2.75V16H1v-2.12a1.5 1.5 0 000-2.75v-.65a1.5 1.5 0 000-2.75v-.65a1.5 1.5 0 000-2.75V2z">
                                        </path>
                                    </mask>
                                    <path
                                        d="M19 2h1V1h-1v1zM1 2V1H0v1h1zm18 2.32l.4.92.6-.26v-.66h-1zm0 2.75h1v-.65l-.6-.26-.4.91zm0 .65l.4.92.6-.26v-.66h-1zm0 2.75h1v-.65l-.6-.26-.4.91zm0 .65l.4.92.6-.26v-.66h-1zm0 2.75h1v-.65l-.6-.26-.4.91zM19 16v1h1v-1h-1zM1 16H0v1h1v-1zm0-2.12l-.4-.92-.6.26v.66h1zm0-2.75H0v.65l.6.26.4-.91zm0-.65l-.4-.92-.6.26v.66h1zm0-2.75H0v.65l.6.26.4-.91zm0-.65l-.4-.92-.6.26v.66h1zm0-2.75H0v.65l.6.26.4-.91zM19 1H1v2h18V1zm1 3.32V2h-2v2.32h2zm-.9 1.38c0-.2.12-.38.3-.46l-.8-1.83a2.5 2.5 0 00-1.5 2.29h2zm.3.46a.5.5 0 01-.3-.46h-2c0 1.03.62 1.9 1.5 2.3l.8-1.84zm.6 1.56v-.65h-2v.65h2zm-.9 1.38c0-.2.12-.38.3-.46l-.8-1.83a2.5 2.5 0 00-1.5 2.29h2zm.3.46a.5.5 0 01-.3-.46h-2c0 1.03.62 1.9 1.5 2.3l.8-1.84zm.6 1.56v-.65h-2v.65h2zm-.9 1.38c0-.2.12-.38.3-.46l-.8-1.83a2.5 2.5 0 00-1.5 2.29h2zm.3.46a.5.5 0 01-.3-.46h-2c0 1.03.62 1.9 1.5 2.3l.8-1.84zM20 16v-2.13h-2V16h2zM1 17h18v-2H1v2zm-1-3.12V16h2v-2.12H0zm1.4.91a2.5 2.5 0 001.5-2.29h-2a.5.5 0 01-.3.46l.8 1.83zm1.5-2.29a2.5 2.5 0 00-1.5-2.3l-.8 1.84c.18.08.3.26.3.46h2zM0 10.48v.65h2v-.65H0zM.9 9.1a.5.5 0 01-.3.46l.8 1.83A2.5 2.5 0 002.9 9.1h-2zm-.3-.46c.18.08.3.26.3.46h2a2.5 2.5 0 00-1.5-2.3L.6 8.65zM0 7.08v.65h2v-.65H0zM.9 5.7a.5.5 0 01-.3.46l.8 1.83A2.5 2.5 0 002.9 5.7h-2zm-.3-.46c.18.08.3.26.3.46h2a2.5 2.5 0 00-1.5-2.3L.6 5.25zM0 2v2.33h2V2H0z"
                                        mask="url(#a)"></path>
                                </g>
                                <path clip-rule="evenodd"
                                    d="M6.49 14.18h.86v-1.6h-.86v1.6zM6.49 11.18h.86v-1.6h-.86v1.6zM6.49 8.18h.86v-1.6h-.86v1.6zM6.49 5.18h.86v-1.6h-.86v1.6z">
                                </path>
                                <defs>
                                    <filter id="voucher-filter0_d" x="0" y="1" width="20" height="16"
                                        filterUnits="userSpaceOnUse" color-interpolation-filters="sRGB">
                                        <feFlood flood-opacity="0" result="BackgroundImageFix"></feFlood>
                                        <feColorMatrix in="SourceAlpha"
                                            values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"></feColorMatrix>
                                        <feOffset></feOffset>
                                        <feGaussianBlur stdDeviation=".5"></feGaussianBlur>
                                        <feColorMatrix values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.09 0">
                                        </feColorMatrix>
                                        <feBlend in2="BackgroundImageFix" result="effect1_dropShadow"></feBlend>
                                        <feBlend in="SourceGraphic" in2="effect1_dropShadow" result="shape"></feBlend>
                                    </filter>
                                </defs>
                            </svg>
                            <span>Voucher của Shop</span>
                            <span class="chooseVouncher">Chọn Voucher</span>
                        </div>
                    </div>
                    <div class="note">
                        <div class="left">
                            <span>Lời nhắn:</span>
                            <input class="note" type="text" placeholder="Lưu ý cho người bán..." />
                        </div>
                        <div class="right">
                            <div class="shipping_method">
                                <div class="info">
                                    <span>Phương thức vận chuyển:</span>
                                    <span style="text-align: left;">Nhanh</span>
                                    <span style="color: #05a; cursor: pointer;">Thay Đổi</span>
                                    <span>₫51.100</span>
                                </div>
                                <div class="desc">
                                    <img
                                        src="https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/checkout/41fe56ab756fc3082a08.svg">
                                    <span>Đảm bảo nhận hàng từ 9 Tháng 1 - 10 Tháng 1</span>
                                </div>
                                <div class="time">
                                    <span>Nhận Voucher trị giá ₫15.000 nếu đơn hàng được giao đến bạn sau ngày 10 Tháng
                                        1 2025</span>
                                </div>
                            </div>
                            <div class="jointly_checked">
                                <span>Được đồng kiểm.</span>
                                <svg enable-background="new 0 0 15 15" viewBox="0 0 15 15" x="0" y="0"
                                    class="shopee-svg-icon YS5UZJ icon-help">
                                    <g>
                                        <circle cx="7.5" cy="7.5" fill="none" r="6.5" stroke-miterlimit="10"></circle>
                                        <path
                                            d="m5.3 5.3c.1-.3.3-.6.5-.8s.4-.4.7-.5.6-.2 1-.2c.3 0 .6 0 .9.1s.5.2.7.4.4.4.5.7.2.6.2.9c0 .2 0 .4-.1.6s-.1.3-.2.5c-.1.1-.2.2-.3.3-.1.2-.2.3-.4.4-.1.1-.2.2-.3.3s-.2.2-.3.4c-.1.1-.1.2-.2.4s-.1.3-.1.5v.4h-.9v-.5c0-.3.1-.6.2-.8s.2-.4.3-.5c.2-.2.3-.3.5-.5.1-.1.3-.3.4-.4.1-.2.2-.3.3-.5s.1-.4.1-.7c0-.4-.2-.7-.4-.9s-.5-.3-.9-.3c-.3 0-.5 0-.7.1-.1.1-.3.2-.4.4-.1.1-.2.3-.3.5 0 .2-.1.5-.1.7h-.9c0-.3.1-.7.2-1zm2.8 5.1v1.2h-1.2v-1.2z"
                                            stroke="none"></path>
                                    </g>
                                </svg>
                            </div>
                        </div>
                    </div>
                    <div class="total">
                        <span class="text">Tổng số tiền (1 sản phẩm):</span>
                        <span class="total">₫492.500</span>
                    </div>
                </div>
            </div>
            <div class="content-product">
                <div class="title">
                    <span class="product">Sản phẩm</span>
                    <span class="amount">Đơn giá</span>
                    <span class="quantity">Số lượng</span>
                    <span class="price">Thành tiền</span>
                </div>
                <div class="detail">
                    <div class="shop">
                        <div class="shopee_mall">
                            <svg viewBox="0 0 24 11">
                                <title>Mall</title>
                                <g fill="#fff" fill-rule="evenodd">
                                    <path
                                        d="M19.615 7.143V1.805a.805.805 0 0 0-1.611 0v5.377H18c0 1.438.634 2.36 1.902 2.77V9.95c.09.032.19.05.293.05.444 0 .805-.334.805-.746a.748.748 0 0 0-.498-.69v-.002c-.59-.22-.885-.694-.885-1.42h-.002zm3 0V1.805a.805.805 0 0 0-1.611 0v5.377H21c0 1.438.634 2.36 1.902 2.77V9.95c.09.032.19.05.293.05.444 0 .805-.334.805-.746a.748.748 0 0 0-.498-.69v-.002c-.59-.22-.885-.694-.885-1.42h-.002zm-7.491-2.985c.01-.366.37-.726.813-.726.45 0 .814.37.814.742v5.058c0 .37-.364.73-.813.73-.395 0-.725-.278-.798-.598a3.166 3.166 0 0 1-1.964.68c-1.77 0-3.268-1.456-3.268-3.254 0-1.797 1.497-3.328 3.268-3.328a3.1 3.1 0 0 1 1.948.696zm-.146 2.594a1.8 1.8 0 1 0-3.6 0 1.8 1.8 0 1 0 3.6 0z">
                                    </path>
                                    <path
                                        d="M.078 1.563A.733.733 0 0 1 .565.89c.423-.15.832.16 1.008.52.512 1.056 1.57 1.88 2.99 1.9s2.158-.85 2.71-1.882c.19-.356.626-.74 1.13-.537.342.138.477.4.472.65a.68.68 0 0 1 .004.08v7.63a.75.75 0 0 1-1.5 0V3.67c-.763.72-1.677 1.18-2.842 1.16a4.856 4.856 0 0 1-2.965-1.096V9.25a.75.75 0 0 1-1.5 0V1.648c0-.03.002-.057.005-.085z"
                                        fill-rule="nonzero"></path>
                                </g>
                            </svg>
                        </div>
                        <span class="nameshop">Cocoon Vietnam Chính Hãng</span>
                        <svg style="width: 20px; height: 15px; color: #00bfa5; fill: currentColor;" viewBox="0 0 16 16"
                            class="shopee-svg-icon FpgzUK">
                            <g fill-rule="evenodd">
                                <path
                                    d="M15 4a1 1 0 01.993.883L16 5v9.932a.5.5 0 01-.82.385l-2.061-1.718-8.199.001a1 1 0 01-.98-.8l-.016-.117-.108-1.284 8.058.001a2 2 0 001.976-1.692l.018-.155L14.293 4H15zm-2.48-4a1 1 0 011 1l-.003.077-.646 8.4a1 1 0 01-.997.923l-8.994-.001-2.06 1.718a.5.5 0 01-.233.108l-.087.007a.5.5 0 01-.492-.41L0 11.732V1a1 1 0 011-1h11.52zM3.646 4.246a.5.5 0 000 .708c.305.304.694.526 1.146.682A4.936 4.936 0 006.4 5.9c.464 0 1.02-.062 1.608-.264.452-.156.841-.378 1.146-.682a.5.5 0 10-.708-.708c-.185.186-.445.335-.764.444a4.004 4.004 0 01-2.564 0c-.319-.11-.579-.258-.764-.444a.5.5 0 00-.708 0z">
                                </path>
                            </g>
                        </svg>
                        <span class="chat">Chat ngay</span>
                    </div>
                    <div class="product">
                        <img src="https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m4k9lc59h3v355@resize_w80_nl.webp"
                            alt="" class="image">
                        <span class="name-product">Tinh chất bí đao (serum) 7% Niacinamide sạch mụn chuyên sâu & mờ vết
                            thâm Cocoon 70ml</span>
                        <span class="amount">₫295.000</span>
                        <span class="quantity">2</span>
                        <span class="price">₫590.000</span>
                    </div>
                    <div class="vouncher">
                        <div class="empty"></div>
                        <div class="vouncher-content">
                            <svg fill="none" viewBox="0 -2 23 22" class="shopee-svg-icon icon-voucher-line">
                                <g filter="url(#voucher-filter0_d)">
                                    <mask id="a" fill="#fff">
                                        <path fill-rule="evenodd" clip-rule="evenodd"
                                            d="M1 2h18v2.32a1.5 1.5 0 000 2.75v.65a1.5 1.5 0 000 2.75v.65a1.5 1.5 0 000 2.75V16H1v-2.12a1.5 1.5 0 000-2.75v-.65a1.5 1.5 0 000-2.75v-.65a1.5 1.5 0 000-2.75V2z">
                                        </path>
                                    </mask>
                                    <path
                                        d="M19 2h1V1h-1v1zM1 2V1H0v1h1zm18 2.32l.4.92.6-.26v-.66h-1zm0 2.75h1v-.65l-.6-.26-.4.91zm0 .65l.4.92.6-.26v-.66h-1zm0 2.75h1v-.65l-.6-.26-.4.91zm0 .65l.4.92.6-.26v-.66h-1zm0 2.75h1v-.65l-.6-.26-.4.91zM19 16v1h1v-1h-1zM1 16H0v1h1v-1zm0-2.12l-.4-.92-.6.26v.66h1zm0-2.75H0v.65l.6.26.4-.91zm0-.65l-.4-.92-.6.26v.66h1zm0-2.75H0v.65l.6.26.4-.91zm0-.65l-.4-.92-.6.26v.66h1zm0-2.75H0v.65l.6.26.4-.91zM19 1H1v2h18V1zm1 3.32V2h-2v2.32h2zm-.9 1.38c0-.2.12-.38.3-.46l-.8-1.83a2.5 2.5 0 00-1.5 2.29h2zm.3.46a.5.5 0 01-.3-.46h-2c0 1.03.62 1.9 1.5 2.3l.8-1.84zm.6 1.56v-.65h-2v.65h2zm-.9 1.38c0-.2.12-.38.3-.46l-.8-1.83a2.5 2.5 0 00-1.5 2.29h2zm.3.46a.5.5 0 01-.3-.46h-2c0 1.03.62 1.9 1.5 2.3l.8-1.84zm.6 1.56v-.65h-2v.65h2zm-.9 1.38c0-.2.12-.38.3-.46l-.8-1.83a2.5 2.5 0 00-1.5 2.29h2zm.3.46a.5.5 0 01-.3-.46h-2c0 1.03.62 1.9 1.5 2.3l.8-1.84zM20 16v-2.13h-2V16h2zM1 17h18v-2H1v2zm-1-3.12V16h2v-2.12H0zm1.4.91a2.5 2.5 0 001.5-2.29h-2a.5.5 0 01-.3.46l.8 1.83zm1.5-2.29a2.5 2.5 0 00-1.5-2.3l-.8 1.84c.18.08.3.26.3.46h2zM0 10.48v.65h2v-.65H0zM.9 9.1a.5.5 0 01-.3.46l.8 1.83A2.5 2.5 0 002.9 9.1h-2zm-.3-.46c.18.08.3.26.3.46h2a2.5 2.5 0 00-1.5-2.3L.6 8.65zM0 7.08v.65h2v-.65H0zM.9 5.7a.5.5 0 01-.3.46l.8 1.83A2.5 2.5 0 002.9 5.7h-2zm-.3-.46c.18.08.3.26.3.46h2a2.5 2.5 0 00-1.5-2.3L.6 5.25zM0 2v2.33h2V2H0z"
                                        mask="url(#a)"></path>
                                </g>
                                <path clip-rule="evenodd"
                                    d="M6.49 14.18h.86v-1.6h-.86v1.6zM6.49 11.18h.86v-1.6h-.86v1.6zM6.49 8.18h.86v-1.6h-.86v1.6zM6.49 5.18h.86v-1.6h-.86v1.6z">
                                </path>
                                <defs>
                                    <filter id="voucher-filter0_d" x="0" y="1" width="20" height="16"
                                        filterUnits="userSpaceOnUse" color-interpolation-filters="sRGB">
                                        <feFlood flood-opacity="0" result="BackgroundImageFix"></feFlood>
                                        <feColorMatrix in="SourceAlpha"
                                            values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"></feColorMatrix>
                                        <feOffset></feOffset>
                                        <feGaussianBlur stdDeviation=".5"></feGaussianBlur>
                                        <feColorMatrix values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.09 0">
                                        </feColorMatrix>
                                        <feBlend in2="BackgroundImageFix" result="effect1_dropShadow"></feBlend>
                                        <feBlend in="SourceGraphic" in2="effect1_dropShadow" result="shape"></feBlend>
                                    </filter>
                                </defs>
                            </svg>
                            <span>Voucher của Shop</span>
                            <span class="chooseVouncher">Chọn Voucher</span>
                        </div>
                    </div>
                    <div class="note">
                        <div class="left">
                            <span>Lời nhắn:</span>
                            <input class="note" type="text" placeholder="Lưu ý cho người bán..." />
                        </div>
                        <div class="right">
                            <div class="shipping_method">
                                <div class="info">
                                    <span>Phương thức vận chuyển:</span>
                                    <span style="text-align: left;">Nhanh</span>
                                    <span style="color: #05a; cursor: pointer;">Thay Đổi</span>
                                    <span>₫51.100</span>
                                </div>
                                <div class="desc">
                                    <img
                                        src="https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/checkout/41fe56ab756fc3082a08.svg">
                                    <span>Đảm bảo nhận hàng từ 9 Tháng 1 - 10 Tháng 1</span>
                                </div>
                                <div class="time">
                                    <span>Nhận Voucher trị giá ₫15.000 nếu đơn hàng được giao đến bạn sau ngày 10 Tháng
                                        1 2025</span>
                                </div>
                            </div>
                            <div class="jointly_checked">
                                <span>Được đồng kiểm.</span>
                                <svg enable-background="new 0 0 15 15" viewBox="0 0 15 15" x="0" y="0"
                                    class="shopee-svg-icon YS5UZJ icon-help">
                                    <g>
                                        <circle cx="7.5" cy="7.5" fill="none" r="6.5" stroke-miterlimit="10"></circle>
                                        <path
                                            d="m5.3 5.3c.1-.3.3-.6.5-.8s.4-.4.7-.5.6-.2 1-.2c.3 0 .6 0 .9.1s.5.2.7.4.4.4.5.7.2.6.2.9c0 .2 0 .4-.1.6s-.1.3-.2.5c-.1.1-.2.2-.3.3-.1.2-.2.3-.4.4-.1.1-.2.2-.3.3s-.2.2-.3.4c-.1.1-.1.2-.2.4s-.1.3-.1.5v.4h-.9v-.5c0-.3.1-.6.2-.8s.2-.4.3-.5c.2-.2.3-.3.5-.5.1-.1.3-.3.4-.4.1-.2.2-.3.3-.5s.1-.4.1-.7c0-.4-.2-.7-.4-.9s-.5-.3-.9-.3c-.3 0-.5 0-.7.1-.1.1-.3.2-.4.4-.1.1-.2.3-.3.5 0 .2-.1.5-.1.7h-.9c0-.3.1-.7.2-1zm2.8 5.1v1.2h-1.2v-1.2z"
                                            stroke="none"></path>
                                    </g>
                                </svg>
                            </div>
                        </div>
                    </div>
                    <div class="total">
                        <span class="text">Tổng số tiền (1 sản phẩm):</span>
                        <span class="total">₫492.500</span>
                    </div>
                </div>
            </div>
            <div class="method_payment">
                <span>Phương thức thanh toán</span>
            </div>
            <div class="content_total">
                <div class="content">
                    <span class="text">Tổng tiền hàng</span>
                    <span class="value">₫326.600</span>
                </div>
                <div class="content">
                    <span class="text">Tổng tiền phí vận chuyển</span>
                    <span class="value">₫198.500</span>
                </div>
                <div class="content">
                    <span class="text">Tổng thanh toán</span>
                    <span class="value-total">₫525.100</span>
                </div>
            </div>
            <div class="payment">
                <span class="text">Nhấn "Đặt hàng" đồng nghĩa với việc bạn đồng ý tuân theo
                    <span class="text-blue"> Điều khoản Shopee</span>
                </span>
                <button class="btn_order">Đặt hàng</button>
            </div>
        </div>
    </div>
</template>

<script>
import baseList from "@/views/base/baseList.js";
import { ref, onMounted, getCurrentInstance } from "vue";
import _ from "lodash";

export default {
    extends: baseList,
    setup() {
    },
};
</script>
<style lang="scss" scoped>
.contentCheckout {
    color: black;

    .checkout {
        padding-top: 12px;
        background: #f5f5f5;

        .content-address {
            background: #fff;
            width: 1200px;
            max-width: 1200px;
            margin: 0 auto;

            .line {
                background-image: repeating-linear-gradient(45deg, #6fa6d6, #6fa6d6 33px, transparent 0, transparent 41px, #f18d9b 0, #f18d9b 74px, transparent 0, transparent 82px);
                background-position-x: -30px;
                background-size: 116px 3px;
                height: 3px;
                width: 100%;
            }

            .address {
                padding: 28px 30px 24px;

                .title {
                    display: flex;
                    align-items: center;
                    gap: 15px;

                    h2 {
                        font-size: inherit;
                        color: #ee4d2d;
                    }
                }

                .desc {
                    margin-top: 20px;
                    display: flex;
                    align-items: center;

                    .name.phonenumber {
                        color: #222;
                        font-weight: 700;
                    }

                    .address-desc {
                        margin-left: 20px;
                        word-break: break-word;
                    }

                    .default {
                        border: .5px solid;
                        border-radius: 1px;
                        color: #ee4d2d;
                        flex-shrink: 0;
                        font-size: 10px;
                        margin-left: 1.5em;
                        padding: 2px 5px;
                        text-transform: capitalize;
                    }

                    .change {
                        color: #4080ee;
                        cursor: pointer;
                        margin-left: 2.5rem;
                        text-transform: capitalize;
                    }
                }
            }
        }

        .content-product {
            width: 1200x;
            max-width: 1200px;
            margin: 0 auto;
            margin-top: 12px;
            padding: 24px 30px 0;
            background: #fff;

            .title {
                height: 50px;
                display: flex;
                align-items: center;
                align-items: center;
                color: #222;
                display: flex;

                .product {
                    font-size: 18px;
                    width: 380px;
                }

                .price,
                .quantity,
                .amount {
                    width: 190px;
                    color: rgba(0, 0, 0, .54);
                    text-align: right;
                }

                .amount {
                    margin-left: auto;
                }
            }

            .detail {

                .shop {
                    display: flex;
                    align-items: center;
                    gap: 10px;
                    height: 50px;

                    .shopee_mall {
                        background-color: #d0011b;
                        border-radius: 2px;
                        box-sizing: border-box;
                        display: inline-block;
                        line-height: 12px;
                        padding: 2px 3px;
                        vertical-align: middle;

                        svg {
                            display: block;
                            fill: #fff;
                            height: 11px;
                            width: 24px;
                        }
                    }

                    .nameshop {
                        font-size: .875rem;
                        padding-right: 10px;
                        border-right: 1px solid rgba(0, 0, 0, .09);
                    }

                    .chat {
                        font-size: .875rem;
                        color: #00bfa5;
                    }
                }

                .product {
                    margin-top: 12px;
                    display: flex;
                    align-items: center;
                    border-bottom: .5px solid rgba(0, 0, 0, .09);
                    padding-bottom: 20px;

                    img {
                        width: 40px;
                        height: 40px;
                    }

                    .name-product {
                        width: 310px;
                        margin-left: 10px;
                        overflow: hidden;
                        text-overflow: ellipsis;
                        white-space: nowrap;
                        color: #222;
                        font-size: 14px;
                    }

                    .amount,
                    .quantity,
                    .price {
                        width: 190px;
                        text-align: right;
                    }

                    .amount {
                        margin-left: auto;
                    }
                }

                .vouncher {
                    height: 72.95px;
                    display: flex;

                    .empty {
                        width: 480px;
                    }

                    .vouncher-content {
                        display: flex;
                        align-items: center;
                        padding: 25px;
                        flex: 1;

                        svg {
                            color: #ee4d2d;
                            height: 22.95px;
                            width: 24px;
                            fill: currentColor;
                            margin-right: 4px;
                        }

                        .chooseVouncher {
                            margin-left: auto;
                            cursor: pointer;
                            text-transform: capitalize;
                            color: #05a !important;
                            font-size: 14px;
                            font-weight: 500;
                            line-height: 21px;
                        }
                    }
                }

                .note {
                    border-top: 1px dashed rgba(0, 0, 0, .09);
                    display: flex;
                    border-bottom: 1px dashed rgba(0, 0, 0, .09);

                    .left {
                        padding: 25px;
                        width: 480px;
                        height: 65px;
                        font-size: 14px;
                        display: flex;
                        align-items: center;

                        .note {
                            width: 355px;
                            height: 40px;
                            margin-left: 15px;
                            background: white;
                            border: 1px solid gray;
                            border-radius: 4px;
                            padding: 10px 10px;
                        }
                    }

                    .right {
                        border-left: 1px dashed rgba(0, 0, 0, .09);
                        flex: 1;

                        .shipping_method {
                            width: 100%;
                            padding: 25px;
                            display: flex;
                            flex-direction: column;
                            gap: 10px;
                            border-bottom: 1px dashed rgba(0, 0, 0, .09);

                            .info {
                                width: 100%;
                                display: flex;
                                justify-content: space-between;
                                font-size: 14px;
                            }

                            .desc {
                                display: flex;
                                font-size: 12px;
                                color: #26aa99;
                            }

                            .time {
                                font-size: 12px;
                                color: #26aa99;
                            }
                        }

                        .jointly_checked {
                            padding: 10px 25px;
                            font-size: 14px;
                            display: flex;
                            align-items: center;

                            svg {
                                margin-left: 6px;
                                width: 16px;
                                height: 16px;
                                stroke: currentColor;
                                color: rgba(0, 0, 0, .54);
                                fill: currentColor;
                            }
                        }
                    }
                }

                .total {
                    padding: 15px 0;
                    display: flex;
                    justify-content: flex-end;
                    align-items: center;

                    .text {
                        color: rgba(0, 0, 0, .54);
                        font-size: .875rem;
                    }

                    .total {
                        padding-left: 20px;
                        color: #ee4d2d;
                        font-size: 20px !important;
                    }
                }
            }
        }

        .method_payment,
        .content_total,
        .payment {
            width: 1200x;
            max-width: 1200px;
            margin: 0 auto;
            margin-top: 12px;
            padding: 24px 30px 0;
            background: #fff;
        }

        .content_total {
            margin-top: 2px;
            padding-bottom: 20px;

            .content {
                display: flex;
                justify-content: flex-end;
                align-items: center;
                height: 40px;

                .text {
                    color: rgba(0, 0, 0, .54);
                    font-size: .875rem;
                    width: 160px;
                    text-align: left;
                }

                .value {
                    font-size: 14px;
                    width: 150px;
                    text-align: right;
                }

                .value-total {
                    width: 150px;
                    text-align: right;
                    color: #ee4d2d;
                    font-size: 28px;
                }
            }
        }

        .payment {
            border-top: 1px dashed rgba(0, 0, 0, .09);
            margin-top: 0;
            padding: 0 30px;
            color: rgba(0, 0, 0, .54);
            font-size: 14px;
            display: flex;
            align-items: center;
            justify-content: space-between;

            span {
                padding: 40px 25px 32px 0;

                .text-blue {
                    color: #4080ee;
                    cursor: pointer;
                }
            }

            .btn_order {
                background: #ee4d2d;
                color: #fff;
                align-items: center;
                font-size: 16px;
                padding: 12px 14px;
                display: flex;
                justify-content: center;
                outline: none;
                border: 1px solid rgba(0, 0, 0, .09);
                border-radius: 2px !important;
                box-shadow: 0 1px 1px 0 rgba(0, 0, 0, .03);
                text-transform: none !important;
                width: 210px;

                &:hover {
                    background: #f05d40;
                }
            }
        }
    }
}

:deep(input) {
    width: 100%;

}
</style>