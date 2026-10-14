let leafletMap,
    drawnItems,
    drawControl,
    routeSequenceLine = null;

let routingControls = [], latLngBounds = [];


import { fetchService, fetchItemService } from './fetchService.js';
import { leafletService } from './leafletService.js';

import { geometryToWKT, wktGeomToGeoJSON } from './TerraformerWKT.js';

//$(document).ready(() => {
document.addEventListener('DOMContentLoaded', () => {
    console.log("InitFastRouteAdmin");
    fastRouteAdmin.init();
    
    window.editProgram = topNavbarAdmin.editProgram;
    window.delProgram = topNavbarAdmin.delProgram;
    window.programPrev = topNavbarAdmin.programPrev;
    window.runProgram = topNavbarAdmin.runProgram;
});

const fastRouteAdmin = {
    init: () => {
        sidebarAdmin.init();
        mainContentAdmin.initMap();
        topNavbarAdmin.init();
    }
}

const sidebarAdmin = {
    init: () => {
        $('.open-sidebar').on('click', () => {
            $('.burger-menu').toggleClass('active');
            $('.sidebar').toggleClass('toggle-sidebar');
            $('.main-content').toggleClass('hide-sidebar');
        });
    }
}

const topNavbarAdmin = {
    init: () => {
        topNavbarAdmin.attachManageProgramEvents();
        topNavbarAdmin.attachAddUpdProgramEvents();
        topNavbarAdmin.attachEventsModalPopup();
        topNavbarAdmin.hadleOnSubmitForm();
    },

    handleProgramOptionClick: async (action, resource) => {
        let request = {
            url: `/Program/${resource}`,
            method: 'GET'
        };
        const { statusCode, item } = await fetchItemService(request);

        if (action?.length && statusCode === 'OK' && !!item)
            topNavbarAdmin[action](item);
    },

    attachManageProgramEvents: () => {
        $('.manage-program, #manage-program-modal #close-modal, #manage-program-modal #close-manage-program').on('click', () => {
            topNavbarAdmin.showManagePrograms();
        });
    },

    attachAddUpdProgramEvents: () => {
        $('#manage-program-modal #add-program, #add-upd-program-modal #close-modal, #add-upd-program-modal #close-add-upd-program').on('click', () => {
            topNavbarAdmin.showProgramModal();
            $("#add-upd-program-modal #form-modal-drawer").attr('op', 1);
            $('#add-upd-program-modal .title').text('Registrar Programa');
            $("#add-upd-program-modal #save-add-upd-program").text("Guardar");
        });
    },

    attachEventsModalPopup: () => {
        $('#popup-modal #close-popup-modal, #popup-modal #close-modal').on('click', () => {
            $('#popup-modal').toggleClass('display');
        });
    },

    hadleOnSubmitForm: () => {
        $(document).on('submit', '#form-modal-drawer', function (e) {
            e.preventDefault();

            const form = $(this);
            const resource = form.attr('resource');
            const action = form.attr('action');
            const method = form.attr('method').toUpperCase();
            let data = Object.fromEntries(new FormData(this).entries());
            data.op = parseInt(form.attr('op'));
            data.numberOfRoutes = parseInt(data.numberOfRoutes);
            data.transportMode = parseInt(data.transportMode);
            //const data = JSON.stringify(form.serialize());

            $.ajax({
                url: action,
                type: method,
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(data),
                success: function (response) {
                    //console.log('Guardado correctamente');
                    if (response?.statusCode === 'OK') {
                        topNavbarAdmin.showProgramModal();
                        topNavbarAdmin.loadManageProgram();
                    }
                },
                error: function (xhr) {
                    console.error('Error al guardar');
                    console.error(xhr.status);
                    console.error(xhr.responseText);
                }
            });
        });


    },

    loadManageProgram: async () => {
        const request = {
            res: 'text',
            url: '/App/ManagePrograms',
            method: 'POST',
            body: JSON.stringify({ description: "" })
        };

        let inputs = await fetchService(request);

        if (inputs.trim().length)
            $('#manage-program-modal .body').html(inputs.trim());
    },

    editProgram: async (resource) => {
        let request = {
            url: `/Program/${resource}`,
            method: 'GET'
        };
        const { statusCode, item } = await fetchItemService(request);

        if (statusCode === 'OK' && !!item) {
            request = {
                res: 'text',
                url: '/App/EditProgram',
                method: 'POST',
                body: JSON.stringify(item)
            };

            let inputs = await fetchService(request);

            if (inputs.trim().length) {
                $('#add-upd-program-modal #form-modal-drawer').attr('resource', item?.uniqueId);
                $('#add-upd-program-modal #form-modal-drawer').attr('op', 2);
                $('#add-upd-program-modal .title').text("Editar Programa");
                $('#add-upd-program-modal #save-add-upd-program').text("Actualizar");
                $('#add-upd-program-modal .body').html(inputs);
                topNavbarAdmin.showProgramModal();
            }
        }
    },

    delProgram: (resource) => {
        $('#popup-modal').toggleClass('display');
    },

    programPrev: (resource) => {
        mainContentAdmin.clearRoutingCtrls();
        topNavbarAdmin.showManagePrograms();
        mainContentAdmin.fetchRoute(resource);
    },

    runProgram: (resource) => {

    },

    showManagePrograms() {
        $('#manage-program-modal').toggleClass('display');
    },

    showProgramModal() {
        $("#add-upd-program-modal #form-modal-drawer")?.[0]?.reset(); // or
        //$("#manage-branch-modal #form-modal-drawer").get(0).reset();

        $('#add-upd-program-modal').toggleClass('display');
        $('#add-upd-program-modal .content').toggleClass('display');
    },

}

const mainContentAdmin = {
    initMap: () => {
        leafletMap = L.map('leaflet-map').setView([-12.046132, -77.031156], 14);

        L.tileLayer('http://{s}.tile.openstreetmap.fr/hot/{z}/{x}/{y}.png', {
            attribution: '&copy; OpenStreetMap'
        }).addTo(leafletMap);

        drawnItems = new L.FeatureGroup();
        leafletMap.addLayer(drawnItems);

        drawControl = new L.Control.Draw({
            draw: {
                position: 'topleft',
                polygon: {
                    allowIntersection: false,
                    shapeOptions: { color: "#2c3e50" }
                    
                },
                polyline: false,
                rectangle: false,
                circle: false,
                marker: false,
                circlemarker: false
            },
            edit: {
                featureGroup: drawnItems,
                remove: true,
                edit: true
            }
        });

        L.drawLocal.draw.toolbar.buttons.polygon = 'Trazar forma.';

        leafletMap.addControl(drawControl);

        mainContentAdmin.onDrawEvent(leafletMap);

        // mainContentAdmin.fetchRoute();

    },

    onDrawEvent: (map) => {
        map.on(L.Draw.Event.CREATED, function (e) {
            const { layerType, layer } = e;
            if (layer instanceof L.Polygon || layerType === 'polygon') {
                // Obtener coordenadas
                const latlngs = layer.getLatLngs();
                console.log("Coordenadas del polígono creado:", latlngs);
                //map.addLayer(layer);
                //drawnItems.addLayer(layer);
            }


            var geojson = layer.toGeoJSON();

            const wktString = geometryToWKT(geojson.geometry);
            console.log('geoJSONToWKT', wktString)

            const geojsonGeom = wktGeomToGeoJSON(wktString);
            console.log('wktToGeoJSON', geojsonGeom)

        });

        map.on(L.Draw.Event.EDITED, function (e) {
            const { layers } = e;
            layers.eachLayer((layer) => {
                console.log("Capa editada:", layer);
            });
        });

        map.on(L.Draw.Event.DELETED, function (e) {
            const { layers } = e;
            layers.eachLayer((layer) => {
                console.log("Capa eliminada:", layer);
            });
        });
    },

    fetchRoute: async (resource = "") => {
        const request = {
            url: '/Program/Preview',
            method: 'POST',
            body: JSON.stringify({
                description: resource
            })
        };

        const result = await fetchService(request);

        if (result.statusCode === 'OK' && result?.items?.length) {
            for (const subItem of result?.items) {
                mainContentAdmin.initRoute(subItem);
            }

            mainContentAdmin.setRoutingZoom();
        }
    },

    initRoute: (route) => {
        const { type, waypoints = [], intermediates = [], lineOptions } = route;
        
        let routingControl = L.Routing.control({
            type,
            waypoints,
            lineOptions
        });

        leafletMap.addControl(routingControl);
        routingControls.push(routingControl);

        mainContentAdmin.setLatLngBounds(waypoints);
        //routingControl.getWaypoints().forEach(wp => latLngBounds.push(wp.latLng));

    },

    setLatLngBounds: (waypoints) => {
        waypoints.forEach((wp, _) => {
            latLngBounds.push(wp);
        });
    },

    setRoutingZoom: () => {
        if (latLngBounds?.length) {
            let bounds = L.latLngBounds(latLngBounds);
            let fit = [bounds.getSouthWest(), bounds.getNorthEast()];
            leafletMap.fitBounds(fit); // | bounds
            leafletMap.setZoom(16);
        }
        
    },

    clearRoutingCtrls: () => {
        routingControls.forEach((ctrl, _) => {
            leafletMap.removeControl(ctrl);
        });
        routingControls = [];

        latLngBounds = [];
    }

}