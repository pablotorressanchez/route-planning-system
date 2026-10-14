import { wktToGeoJSON, geojsonToWKT } from 'https://unpkg.com/@terraformer/wkt?module';

export function geometryToWKT(geometry) {
    return geojsonToWKT(geometry);
}

export function wktGeomToGeoJSON(wkt) {
    return wktToGeoJSON(wkt);
}