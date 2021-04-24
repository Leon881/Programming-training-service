import { combineReducers } from 'redux';
import { createReducer } from 'redux-create-reducer';
import Page from '../constants/Page';
import * as actionTypes from '../actionTypes';


const pageReducer=createReducer(Page.mainMenu,{[actionTypes.NAVIGATE_TO_PAGE]:(state,action)=>action.page});
const textReducer=createReducer(null,{[actionTypes.SET_INFORMATION]:(state,action)=>action.value});

export const rootReducer = combineReducers({
    page: pageReducer,
    text:textReducer
});