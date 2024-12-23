<template>
    <div class="search">
        <!-- filter -->
        <div class="left">
            <span class="title">BỘ LỌC TÌM KIẾM</span>
            <div class="filter">
                <p>Theo danh mục</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Nội thất văn phòng (3k+)</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Nội thất ngoài trời (1k+)</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Nội thất phòng ăn (315)</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Ô Tô & Xe Máy & Xe Đạp (245)</span>
                </div>
                <div class="more">
                    <span>Thêm</span>
                    <svg style="width: 7px; height: 7px;" enable-background="new 0 0 11 11" viewBox="0 0 11 11" x="0"
                        y="0" class="shopee-svg-icon icon-arrow-down">
                        <g>
                            <path
                                d="m11 2.5c0 .1 0 .2-.1.3l-5 6c-.1.1-.3.2-.4.2s-.3-.1-.4-.2l-5-6c-.2-.2-.1-.5.1-.7s.5-.1.7.1l4.6 5.5 4.6-5.5c.2-.2.5-.2.7-.1.1.1.2.3.2.4z">
                            </path>
                        </g>
                    </svg>
                </div>
            </div>
            <div class="filter">
                <p>Nơi Bán</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Hà Nội</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">TP. Hồ Chí Minh</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Quận Hà Đông</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Quận Hoàng Mai</span>
                </div>
                <div class="more">
                    <span>Thêm</span>
                    <svg style="width: 7px; height: 7px;" enable-background="new 0 0 11 11" viewBox="0 0 11 11" x="0"
                        y="0" class="shopee-svg-icon icon-arrow-down">
                        <g>
                            <path
                                d="m11 2.5c0 .1 0 .2-.1.3l-5 6c-.1.1-.3.2-.4.2s-.3-.1-.4-.2l-5-6c-.2-.2-.1-.5.1-.7s.5-.1.7.1l4.6 5.5 4.6-5.5c.2-.2.5-.2.7-.1.1.1.2.3.2.4z">
                            </path>
                        </g>
                    </svg>
                </div>
            </div>
            <div class="filter">
                <p>Đơn Vị Vận Chuyển</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Hỏa tốc</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Nhanh</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Tiết kiệm</span>
                </div>
            </div>
            <div class="filter">
                <p>Thương Hiệu</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Manson</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Sihoo</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">GTChair</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Anzani</span>
                </div>
                <div class="more">
                    <span>Thêm</span>
                    <svg style="width: 7px; height: 7px;" enable-background="new 0 0 11 11" viewBox="0 0 11 11" x="0"
                        y="0" class="shopee-svg-icon icon-arrow-down">
                        <g>
                            <path
                                d="m11 2.5c0 .1 0 .2-.1.3l-5 6c-.1.1-.3.2-.4.2s-.3-.1-.4-.2l-5-6c-.2-.2-.1-.5.1-.7s.5-.1.7.1l4.6 5.5 4.6-5.5c.2-.2.5-.2.7-.1.1.1.2.3.2.4z">
                            </path>
                        </g>
                    </svg>
                </div>
            </div>
            <div class="filter">
                <p>Khoảng Giá</p>
                <div class="form">
                    <InputText placeholder="₫ TỪ"></InputText>
                    <span>-</span>
                    <InputText placeholder="₫ ĐẾN"></InputText>
                </div>
                <button class="btn-apply">
                    <span>ÁP DỤNG</span>
                </button>
            </div>
            <div class="filter">
                <p>Loại Shop</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Shopee Mall</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Shop Yêu thích</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Shop Yêu Thích +</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Shop Xu Hướng</span>
                </div>
            </div>
            <div class="filter">
                <p>Tình Trạng</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Đã sử dụng</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Mới</span>
                </div>
            </div>
            <div class="filter">
                <p>Các lựa chọn thanh toán</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">0% TRẢ GÓP</span>
                </div>
            </div>
            <div class="filter">
                <p>Đánh Giá</p>
                <div class="item-rate">
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                </div>
                <div class="item-rate">
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 30 30" class="TcqD9P">
                        <defs>
                            <linearGradient id="star__hollow" x1="50%" x2="50%" y1="0%" y2="99.0177926%">
                                <stop offset="0%" stop-color="#FFD211"></stop>
                                <stop offset="100%" stop-color="#FFAD27"></stop>
                            </linearGradient>
                        </defs>
                        <path fill="none" fill-rule="evenodd" stroke="url(#star__hollow)" stroke-width="2"
                            d="M23.226809 28.390899l-1.543364-9.5505903 6.600997-6.8291523-9.116272-1.4059447-4.01304-8.63019038-4.013041 8.63019038-9.116271 1.4059447 6.600997 6.8291523-1.543364 9.5505903 8.071679-4.5038874 8.071679 4.5038874z">
                        </path>
                    </svg>
                    <span>trở lên</span>
                </div>
                <div class="item-rate">
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 30 30" class="TcqD9P">
                        <defs>
                            <linearGradient id="star__hollow" x1="50%" x2="50%" y1="0%" y2="99.0177926%">
                                <stop offset="0%" stop-color="#FFD211"></stop>
                                <stop offset="100%" stop-color="#FFAD27"></stop>
                            </linearGradient>
                        </defs>
                        <path fill="none" fill-rule="evenodd" stroke="url(#star__hollow)" stroke-width="2"
                            d="M23.226809 28.390899l-1.543364-9.5505903 6.600997-6.8291523-9.116272-1.4059447-4.01304-8.63019038-4.013041 8.63019038-9.116271 1.4059447 6.600997 6.8291523-1.543364 9.5505903 8.071679-4.5038874 8.071679 4.5038874z">
                        </path>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 30 30" class="TcqD9P">
                        <defs>
                            <linearGradient id="star__hollow" x1="50%" x2="50%" y1="0%" y2="99.0177926%">
                                <stop offset="0%" stop-color="#FFD211"></stop>
                                <stop offset="100%" stop-color="#FFAD27"></stop>
                            </linearGradient>
                        </defs>
                        <path fill="none" fill-rule="evenodd" stroke="url(#star__hollow)" stroke-width="2"
                            d="M23.226809 28.390899l-1.543364-9.5505903 6.600997-6.8291523-9.116272-1.4059447-4.01304-8.63019038-4.013041 8.63019038-9.116271 1.4059447 6.600997 6.8291523-1.543364 9.5505903 8.071679-4.5038874 8.071679 4.5038874z">
                        </path>
                    </svg>
                    <span>trở lên</span>
                </div>
                <div class="item-rate">
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 9.5 8"
                        class="shopee-svg-icon rating-stars__star icon-rating-colored">
                        <defs>
                            <linearGradient id="ratingStarGradient" x1="50%" x2="50%" y1="0%" y2="100%">
                                <stop offset="0" stop-color="#ffca11"></stop>
                                <stop offset="1" stop-color="#ffad27"></stop>
                            </linearGradient>
                            <polygon id="ratingStar"
                                points="14.910357 6.35294118 12.4209136 7.66171903 12.896355 4.88968305 10.8823529 2.92651626 13.6656353 2.52208166 14.910357 0 16.1550787 2.52208166 18.9383611 2.92651626 16.924359 4.88968305 17.3998004 7.66171903">
                            </polygon>
                        </defs>
                        <g fill="url(#ratingStarGradient)" fill-rule="evenodd" stroke="none" stroke-width="1">
                            <g transform="translate(-876 -1270)">
                                <g transform="translate(155 992)">
                                    <g transform="translate(600 29)">
                                        <g transform="translate(10 239)">
                                            <g transform="translate(101 10)">
                                                <use stroke="#ffa727" stroke-width=".5" xlink:href="#ratingStar"></use>
                                            </g>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </g>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 30 30" class="TcqD9P">
                        <defs>
                            <linearGradient id="star__hollow" x1="50%" x2="50%" y1="0%" y2="99.0177926%">
                                <stop offset="0%" stop-color="#FFD211"></stop>
                                <stop offset="100%" stop-color="#FFAD27"></stop>
                            </linearGradient>
                        </defs>
                        <path fill="none" fill-rule="evenodd" stroke="url(#star__hollow)" stroke-width="2"
                            d="M23.226809 28.390899l-1.543364-9.5505903 6.600997-6.8291523-9.116272-1.4059447-4.01304-8.63019038-4.013041 8.63019038-9.116271 1.4059447 6.600997 6.8291523-1.543364 9.5505903 8.071679-4.5038874 8.071679 4.5038874z">
                        </path>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 30 30" class="TcqD9P">
                        <defs>
                            <linearGradient id="star__hollow" x1="50%" x2="50%" y1="0%" y2="99.0177926%">
                                <stop offset="0%" stop-color="#FFD211"></stop>
                                <stop offset="100%" stop-color="#FFAD27"></stop>
                            </linearGradient>
                        </defs>
                        <path fill="none" fill-rule="evenodd" stroke="url(#star__hollow)" stroke-width="2"
                            d="M23.226809 28.390899l-1.543364-9.5505903 6.600997-6.8291523-9.116272-1.4059447-4.01304-8.63019038-4.013041 8.63019038-9.116271 1.4059447 6.600997 6.8291523-1.543364 9.5505903 8.071679-4.5038874 8.071679 4.5038874z">
                        </path>
                    </svg>
                    <svg style="width: 14px; height: 14px;" viewBox="0 0 30 30" class="TcqD9P">
                        <defs>
                            <linearGradient id="star__hollow" x1="50%" x2="50%" y1="0%" y2="99.0177926%">
                                <stop offset="0%" stop-color="#FFD211"></stop>
                                <stop offset="100%" stop-color="#FFAD27"></stop>
                            </linearGradient>
                        </defs>
                        <path fill="none" fill-rule="evenodd" stroke="url(#star__hollow)" stroke-width="2"
                            d="M23.226809 28.390899l-1.543364-9.5505903 6.600997-6.8291523-9.116272-1.4059447-4.01304-8.63019038-4.013041 8.63019038-9.116271 1.4059447 6.600997 6.8291523-1.543364 9.5505903 8.071679-4.5038874 8.071679 4.5038874z">
                        </path>
                    </svg>
                    <span>trở lên</span>
                </div>
                <div class="more">
                    <span>Thêm</span>
                    <svg style="width: 7px; height: 7px;" enable-background="new 0 0 11 11" viewBox="0 0 11 11" x="0"
                        y="0" class="shopee-svg-icon icon-arrow-down">
                        <g>
                            <path
                                d="m11 2.5c0 .1 0 .2-.1.3l-5 6c-.1.1-.3.2-.4.2s-.3-.1-.4-.2l-5-6c-.2-.2-.1-.5.1-.7s.5-.1.7.1l4.6 5.5 4.6-5.5c.2-.2.5-.2.7-.1.1.1.2.3.2.4z">
                            </path>
                        </g>
                    </svg>
                </div>
            </div>
            <div class="filter">
                <p>Dịch Vụ & Khuyến Mãi</p>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Đang giảm giá</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Miễn phí vận chuyển</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Gì Cũng Rẻ</span>
                </div>
                <div class="item">
                    <Checkbox></Checkbox>
                    <span class="value">Hàng có sẵn</span>
                </div>
                <div class="more">
                    <span>Thêm</span>
                    <svg style="width: 7px; height: 7px;" enable-background="new 0 0 11 11" viewBox="0 0 11 11" x="0"
                        y="0" class="shopee-svg-icon icon-arrow-down">
                        <g>
                            <path
                                d="m11 2.5c0 .1 0 .2-.1.3l-5 6c-.1.1-.3.2-.4.2s-.3-.1-.4-.2l-5-6c-.2-.2-.1-.5.1-.7s.5-.1.7.1l4.6 5.5 4.6-5.5c.2-.2.5-.2.7-.1.1.1.2.3.2.4z">
                            </path>
                        </g>
                    </svg>
                </div>
            </div>
            <div class="filter">
                <button class="btn-remove-filter">
                    <span>XÓA TẤT CẢ</span>
                </button>
            </div>
        </div>
        <!-- list product -->
        <div class="right">
            <div class="title">
                <svg style="width: 16px; height: 22px;" viewBox="0 0 18 24" class="shopee-svg-icon icon-hint-bulb">
                    <g transform="translate(-355 -149)">
                        <g transform="translate(355 149)">
                            <g fill-rule="nonzero" transform="translate(5.4 19.155556)">
                                <path
                                    d="m1.08489412 1.77777778h5.1879153c.51164401 0 .92641344-.39796911.92641344-.88888889s-.41476943-.88888889-.92641344-.88888889h-5.1879153c-.51164402 0-.92641345.39796911-.92641345.88888889s.41476943.88888889.92641345.88888889z">
                                </path>
                                <g transform="translate(1.9 2.666667)">
                                    <path
                                        d="m .75 1.77777778h2.1c.41421356 0 .75-.39796911.75-.88888889s-.33578644-.88888889-.75-.88888889h-2.1c-.41421356 0-.75.39796911-.75.88888889s.33578644.88888889.75.88888889z">
                                    </path>
                                </g>
                            </g>
                            <path
                                d="m8.1 8.77777718v4.66666782c0 .4295545.40294373.7777772.9.7777772s.9-.3482227.9-.7777772v-4.66666782c0-.42955447-.40294373-.77777718-.9-.77777718s-.9.34822271-.9.77777718z"
                                fill-rule="nonzero"></path>
                            <path
                                d="m8.1 5.33333333v.88889432c0 .49091978.40294373.88888889.9.88888889s.9-.39796911.9-.88888889v-.88889432c0-.49091977-.40294373-.88888889-.9-.88888889s-.9.39796912-.9.88888889z"
                                fill-rule="nonzero"></path>
                            <path
                                d="m8.80092773 0c-4.86181776 0-8.80092773 3.97866667-8.80092773 8.88888889 0 1.69422221.47617651 3.26933331 1.295126 4.61333331l2.50316913 3.9768889c.30201078.4782222.84303623.7697778 1.42482388.7697778h7.17785139c.7077799 0 1.3618277-.368 1.7027479-.9617778l2.3252977-4.0213333c.7411308-1.2888889 1.1728395-2.7786667 1.1728395-4.37688891 0-4.91022222-3.9409628-8.88888889-8.80092777-8.88888889m0 1.77777778c3.82979317 0 6.94810087 3.18933333 6.94810087 7.11111111 0 1.24444441-.3168334 2.43022221-.9393833 3.51466671l-2.3252977 4.0213333c-.0166754.0284444-.0481735.0462222-.0833772.0462222h-7.07224026l-2.43461454-3.8648889c-.68184029-1.12-1.04128871-2.4053333-1.04128871-3.71733331 0-3.92177778 3.11645483-7.11111111 6.94810084-7.11111111">
                            </path>
                        </g>
                    </g>
                </svg>
                <span>Kết quả tìm kiếm cho từ khoá</span>
                <span class="text-search">'ghế công thái học'</span>
            </div>
            <div class="sort">
                <span>Sắp xếp theo</span>
                <button class="btn active">
                    <span>Liên quan</span>
                </button>
                <button class="btn">
                    <span>Mới nhất</span>
                </button>
                <button class="btn">
                    <span>Bán chạy</span>
                </button>
                <Select placeholder="Giá"></Select>
                <div class="page">
                    <span>1/17</span>
                    <button class="btn prev">
                        <svg style="width: 10px; height: 10px;" viewBox="0 0 7 11"
                            class="shopee-svg-icon icon-arrow-left-small">
                            <path
                                d="M4.694078 9.8185598L.2870824 5.4331785c-.1957415-.1947815-.1965198-.511363-.0017382-.7071046a.50867033.50867033 0 0 1 .000868-.0008702L4.7381375.2732784 4.73885.273991c.1411545-.127878.3284279-.205779.5338961-.205779.4393237 0 .7954659.3561422.7954659.7954659 0 .2054682-.077901.3927416-.205779.5338961l.0006632.0006632-.0226101.0226101a.80174653.80174653 0 0 1-.0105706.0105706L2.4680138 4.7933195c-.1562097.1562097-.1562097.4094757 0 .5656855a.45579485.45579485 0 0 0 .0006962.0006944l3.3930018 3.3763607-.0009482.0009529c.128869.1413647.2074484.3293723.2074484.5357331 0 .4393237-.3561422.7954659-.7954659.7954659-.2049545 0-.391805-.077512-.5328365-.2048207l-.0003877.0003896-.0097205-.0096728a.80042023.80042023 0 0 1-.0357234-.0355483z"
                                fill-rule="nonzero"></path>
                        </svg>
                    </button>
                    <button class="btn next">
                        <svg style="width: 10px; height: 10px;" viewBox="0 0 7 11"
                            class="shopee-svg-icon icon-arrow-right-small">
                            <path
                                d="M2.305922 9.81856l4.4069956-4.385381c.1957415-.194782.1965198-.511364.0017382-.707105a.26384055.26384055 0 0 0-.000868-.00087L2.2618625.273278 2.26115.273991C2.1199955.146113 1.9327221.068212 1.7272539.068212c-.4393237 0-.7954659.356142-.7954659.795466 0 .205468.077901.392741.205779.533896l-.0006632.000663.0226101.02261c.0034906.003557.0070143.00708.0105706.010571L4.5319862 4.79332c.1562097.156209.1562097.409475 0 .565685-.0002318.000232-.0004639.000463-.0006962.000694L1.1382882 8.73606l.0009482.000953c-.128869.141365-.2074484.329372-.2074484.535733 0 .439324.3561422.795466.7954659.795466.2049545 0 .391805-.077512.5328365-.204821l.0003877.00039.0097205-.009673c.012278-.011471.0241922-.023327.0357234-.035548z"
                                fill-rule="nonzero"></path>
                        </svg>
                    </button>
                </div>
            </div>
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
export default defineComponent({
    name: "Search",
    setup() {
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
            products,
            goToProductDetail
        };
    },
});
</script>

<style lang="scss" scoped>
.search {
    color: black;
    width: 1200px;
    margin: 0 auto;
    margin-top: 20px;
    display: flex;

    .left {
        width: 190px;
        margin-right: 20px;

        .title {
            flex: 1;
            font-size: 1rem;
            font-weight: 700;
        }

        .filter {
            margin-top: 20px;
            padding-bottom: 20px;
            border-bottom: 1px solid rgba(0, 0, 0, .09);

            .item {
                margin-top: 10px;
                display: flex;
                align-items: center;
                font-size: .875rem;

                .value {
                    margin-left: 5px;
                }
            }

            .more {
                margin-left: 22px;
                margin-top: 10px;
                display: flex;
                align-items: center;
                gap: 10px;
                font-size: .875rem;
            }

            .form {
                margin-top: 20px;
                display: flex;
                justify-content: space-between;
            }

            .btn-apply,
            .btn-remove-filter {
                margin-top: 10px;
                height: 30px;
                display: flex;
                align-items: center;
                justify-content: center;
                padding: 0 20px;
                background: #ee4d2d;
                color: #fff;
                width: 100%;
            }

            .item-rate {
                display: flex;
                align-items: center;
                gap: 3px;
                margin-top: 10px;
                font-size: 14px;

                span {
                    margin-left: 5px;
                }
            }
        }
    }

    .right {
        flex: 1;

        .title {
            display: flex;

            svg {
                margin-right: 10px;
            }

            .text-search {
                margin-left: 6px;
                color: #ee4d2d;
            }
        }

        .sort {
            display: flex;
            align-items: center;
            gap: 15px;
            padding: 13px 20px;
            background: rgba(0, 0, 0, .03);
            margin-top: 24px;

            .btn {
                height: 34px;
                width: 90px;
                display: flex;
                align-items: center;
                justify-content: center;
                background-color: #fff;

                &.active {
                    background: #ee4d2d;
                    color: #fff;
                }
            }

            .page {
                margin-left: auto;
                display: flex;
                align-items: center;

                .btn {
                    height: 38px;
                    width: 38px;
                    display: flex;
                    align-items: center;
                    justify-content: center;
                    background-color: #fff;

                    &.prev {
                        margin-left: 20px;
                    }
                }
            }
        }

        .product-grid {
            margin-top: 10px;
            display: grid;
            grid-template-columns: repeat(4, 1fr); // 6 sản phẩm mỗi dòng
            gap: 20px;

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
                    height: 220px;
                    object-fit: cover;
                }

                .product-info {
                    padding: 10px;

                    .product-name {
                        font-size: 14px;
                        color: #333;
                        margin-bottom: 5px;
                        line-height: 1.4;
                    }

                    .product-price {
                        font-size: 16px;
                        font-weight: bold;
                        color: #f53d2d;
                        margin-bottom: 5px;
                    }

                    .product-sold {
                        font-size: 12px;
                        color: #999;
                    }
                }
            }
        }
    }
}

:deep(.p-checkbox-box) {
    background: white;
}

:deep(.p-inputtext.p-component) {
    width: 80px;
    height: 30px;
    font-size: 12px;
    background: white;
}

:deep(.p-select.p-component.p-inputwrapper) {
    background: white;
    height: 34px;
    width: 200px;
    font-size: 13px;
}
</style>
