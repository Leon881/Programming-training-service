import * as actionTypes from '../actionTypes';

export const navigateTo = page => ({
    type: actionTypes.NAVIGATE_TO_PAGE,
    page
});

export const setInformation = value=> ({
    type: actionTypes.SET_INFORMATION,
    value
});

export const setArticlesList = value=> ({
    type: actionTypes.SET_ARTICLES_LIST,
    value
});