import * as actionTypes from '../actionTypes';

export const navigateToPage = page => ({
    type: actionTypes.NAVIGATE_TO_PAGE,
    page
});

export const setAccordionMenuInf = value => ({
    type: actionTypes.LOAD_ACCORDION_MENU_INF_SUCCESS,
    value
});

export const requestAccordionMenuInf = () => ({
    type: actionTypes.LOAD_ACCORDION_MENU_INF_REQUEST
});

export const setLearningText = text => ({
    type: actionTypes.LOAD_LEARNING_TEXT_SUCCESS,
    text
});

export const requestLearningText = () => ({
    type: actionTypes.LOAD_LEARNING_TEXT_REQUEST
});

export const setLearningTextDefault = () => ({
    type: actionTypes.SET_LEARNING_TEXT_DEFAULT
});

export const setArticles = articles => ({
    type: actionTypes.LOAD_ARTICLES_SUCCESS,
    articles
});

export const requestArticles = () => ({
    type: actionTypes.LOAD_ARTICLES_REQUEST
});

export const setUserInformation = (data) => ({
    type: actionTypes.SET_USER_INFORMATION,
    data
});