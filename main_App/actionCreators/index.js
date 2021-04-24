import * as actionTypes from '../actionTypes';

export const navigateToPage = page => ({
    type: actionTypes.NAVIGATE_TO_PAGE,
    page
});

export const setInformation = value=> ({
    type: actionTypes.SET_INFORMATION,
    value
});