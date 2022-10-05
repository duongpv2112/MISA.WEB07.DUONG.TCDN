<template>
    <div class="navigation-action__list">
        <a
            :class="{
                'first-page': currentPage == 1,
                'disabled-text': dataReady,
            }"
        >
            Trước
        </a>
        <div class="navigation-action__number">
            <a
                v-for="(pageNumber, index) of pageNumbers"
                :key="index + '_' + pageNumber"
                :class="{
                    active: pageNumber.numberPage == currentPage,
                    'disabled-text': dataReady,
                    nextPage: pageNumber.nextPage,
                    prevPage: pageNumber.prevPage,
                }"
                @click="
                    pageNumber.numberPage == '...'
                        ? clickDotted(pageSize, total)
                        : null
                "
            >
                {{ pageNumber.numberPage }}
            </a>
        </div>
        <a
            :class="{
                'last-page': currentPage == total,
                'disabled-text': dataReady,
            }"
        >
            Sau
        </a>
    </div>
</template>
<script>
export default {
    name: "BasePagination",
    props: {
        dataReady: Boolean,
        currentPage: Number,
        pageSize: Number,
        total: Number,
    },
    data() {
        return {
            pageNumbers: [],
            tempPage: 0,
        };
    },
    created() {
        this.tempPage = this.currentPage;
        this.renderPagination(this.pageSize, this.total);
    },
    methods: {
        renderPagination(pageSize, total) {
            try {
                var totalPage = Math.ceil(total / pageSize);

                if (totalPage >= 5) {
                    if (this.currentPage == 1 || this.currentPage == 2) {
                        this.pageNumbers = [
                            {
                                numberPage: "1",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "2",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "3",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "...",
                                nextPage: true,
                                prevPage: false,
                            },
                            {
                                numberPage: `${totalPage}`,
                                nextPage: false,
                                prevPage: false,
                            },
                        ];
                    } else if (
                        this.currentPage == totalPage ||
                        this.currentPage == totalPage - 1 ||
                        this.currentPage == totalPage - 2
                    ) {
                        this.pageNumbers = [
                            {
                                numberPage: "1",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "...",
                                nextPage: true,
                                prevPage: false,
                            },
                            {
                                numberPage: `${totalPage - 2}`,
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: `${totalPage - 1}`,
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: `${totalPage}`,
                                nextPage: false,
                                prevPage: false,
                            },
                        ];
                    }
                } else {
                    this.pages = totalPage;
                }
            } catch (error) {
                console.log(error);
            }
        },

        clickDotted(pageSize, total) {
            try {
                var totalPage = Math.ceil(total / pageSize);
                if (event.target.classList.contains("nextPage")) {
                    this.pageNumbers = [
                        {
                            numberPage: "1",
                            nextPage: false,
                            prevPage: false,
                        },
                        {
                            numberPage: "...",
                            nextPage: false,
                            prevPage: true,
                        },
                        {
                            numberPage: `${this.tempPage + 3}`,
                            nextPage: false,
                            prevPage: false,
                        },
                        {
                            numberPage: `${this.tempPage + 4}`,
                            nextPage: false,
                            prevPage: false,
                        },
                        {
                            numberPage: `${this.tempPage + 5}`,
                            nextPage: false,
                            prevPage: false,
                        },
                        {
                            numberPage: "...",
                            nextPage: true,
                            prevPage: false,
                        },
                        {
                            numberPage: `${totalPage}`,
                            nextPage: false,
                            prevPage: true,
                        },
                    ];
                    this.tempPage = this.tempPage + 3;
                } else if (event.target.classList.contains("prevPage")) {
                    if (this.tempPage <= 4) {
                        this.pageNumbers = [
                            {
                                numberPage: "1",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "2",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "3",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "...",
                                nextPage: true,
                                prevPage: false,
                            },
                            {
                                numberPage: `${totalPage}`,
                                nextPage: false,
                                prevPage: false,
                            },
                        ];
                    } else
                        this.pageNumbers = [
                            {
                                numberPage: "1",
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "...",
                                nextPage: false,
                                prevPage: true,
                            },
                            {
                                numberPage: `${this.tempPage - 3}`,
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: `${this.tempPage - 2}`,
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: `${this.tempPage - 1}`,
                                nextPage: false,
                                prevPage: false,
                            },
                            {
                                numberPage: "...",
                                nextPage: true,
                                prevPage: false,
                            },
                            {
                                numberPage: `${totalPage}`,
                                nextPage: false,
                                prevPage: true,
                            },
                        ];
                    this.tempPage = this.tempPage - 3;
                }
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped></style>
