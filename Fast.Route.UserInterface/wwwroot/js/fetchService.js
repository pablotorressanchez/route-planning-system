const baseUrl = window.location.origin;
const defaultStatus = {
    statusCode: '00',
    statusMessage: 'No pudimos conectarnos al servidor.'
}

/*
 Method         Expected Content Type       Returned JavaScript Type
 .json()        application/json            Object / Array / Number / String
 .text()        text/plain, text/html       String
 .blob()        image/*, application/pdf    Blob (File-like object)
 .arrayBuffer() Any binary (.wasm, .bin)    ArrayBuffer (Raw memory bytes)
 .formData()    multipart/form-data         FormData object
 */

export const fetchService = async ({ url, res, ...request }) => {
    const requestInit = {
        ...request,
        headers: {
            'Content-Type': 'application/json'
        }
    };

    const response = await fetch(`${baseUrl}${url}`, requestInit);
    if (!response.ok)
        return new Promise((_, reject) => reject((
            {
                ...defaultStatus,
                items: []
            }
        )));

    if(!!res && res === 'text')
        return await response.text();

    return await response.json();
}

export const fetchItemService = async ({ url, res, ...request }) => {
    const requestInit = {
        ...request,
        headers: {
            'Content-Type': 'application/json'
        }
    };

    const response = await fetch(`${baseUrl}${url}`, requestInit);
    if (!response.ok)
        return new Promise((_, reject) => reject((
            {
                ...defaultStatus,
                item: null
            }
        )));

    if (!!res && res === 'text')
        return await response.text();

    return await response.json();
}

export const fetchGeoJsonDistrict = async () => {
    const response = await fetch('/json/lima_distritos.json');

    if (!response.ok)
        return new Promise((_, reject) => reject({
            type: "FeatureCollection",
            features: []
        }))
    return await response.json();
}