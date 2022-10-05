import axios from "axios";
import CONFIG_API from "./config";

export default {
    /**
     * Function gọi api có method get
     * @param {*} url Url API cần gọi
     * @param {*} querys Parameters cần truyền thêm cho API (nếu có)
     * querys = [{field: EmployeeName, value: "Dương"}]
     * @returns Trả ra dữ liệu trả về từ API
     * AUTHOR: DUONGPV (04/10/2022)
     */
    get(url, querys) {
        try {
            let lastUrl = CONFIG_API.BASE_DOMAIN + CONFIG_API.BASE_URL + url;
            if (querys) {
                lastUrl += "?";
                for (const query of querys) {
                    lastUrl = lastUrl + `${query.field}=${query.value}&`;
                }
            }
            return axios.get(lastUrl).then((response) => {
                return response.data;
            });
        } catch (error) {
            console.log(error);
        }
    },

    /**
     * Function gọi api có method post
     * @param {*} url Url API cần gọi
     * @param {*} data Data cần truyền vào body của API
     * @returns Trả ra thông báo thành công hay thất bại
     * AUTHOR: DUONGPV (04/10/2022)
     */
    post(url, data) {
        try {
            let lastUrl = CONFIG_API.BASE_DOMAIN + CONFIG_API.BASE_URL + url;
            return axios.post(lastUrl, data).then((response) => {
                return response.data;
            });
        } catch (error) {
            console.log(error);
        }
    },

    /**
     * Function gọi api có method post
     * @param {*} url Url API cần gọi
     * @param {*} data Data cần truyền vào body của API
     * @returns Trả ra thông báo thành công hay thất bại
     * AUTHOR: DUONGPV (04/10/2022)
     */
    export(url, nameDownload) {
        try {
            let lastUrl = CONFIG_API.BASE_DOMAIN + CONFIG_API.BASE_URL + url;
            var config = {
                method: "POST",
                url: lastUrl,
                headers: {
                    "Content-Type": "application/json",
                },
                responseType: "blob",
            };

            return axios(config).then((response) => {
                const url = window.URL.createObjectURL(
                    new Blob([response.data])
                );
                const link = document.createElement("a");
                link.href = url;
                link.target = "_blank";
                link.setAttribute("download", `${nameDownload}`);
                document.body.appendChild(link);
                link.click();
            });
        } catch (error) {
            console.log(error);
        }
    },

    /**
     * Function gọi api có method put
     * @param {*} url Url API cần gọi
     * @param {*} data Data cần truyền vào body của API
     * @returns Trả ra thông báo thành công hay thất bại
     * AUTHOR: DUONGPV (04/10/2022)
     */
    put(url, data) {
        try {
            let lastUrl = CONFIG_API.BASE_DOMAIN + CONFIG_API.BASE_URL + url;
            return axios.put(lastUrl, data).then((response) => {
                return response.data;
            });
        } catch (error) {
            console.log(error);
        }
    },

    /**
     * Function gọi api có method put
     * @param {*} url Url API cần gọi
     * @returns Trả ra thông báo thành công hay thất bại
     * AUTHOR: DUONGPV (04/10/2022)
     */
    delete(url) {
        try {
            let lastUrl = CONFIG_API.BASE_DOMAIN + CONFIG_API.BASE_URL + url;
            return axios.delete(lastUrl).then((response) => {
                return response.data;
            });
        } catch (error) {
            console.log(error);
        }
    },

    /**
     * Function gọi api có method put
     * @param {*} url Url API cần gọi
     * @param {*} data Data cần truyền về API
     * @returns Trả ra thông báo thành công hay thất bại
     * AUTHOR: DUONGPV (04/10/2022)
     */
    deleteMultiple(url, data) {
        try {
            let lastUrl = CONFIG_API.BASE_DOMAIN + CONFIG_API.BASE_URL + url;
            var config = {
                method: "DELETE",
                url: lastUrl,
                headers: {
                    "Content-Type": "application/json",
                },
                data: data,
            };

            return axios(config)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        } catch (error) {
            console.log(error);
        }
    },
};
