import produce from 'immer';

export default function product(state = [], action) {
  debugger;
  switch (action.type) {
    case '@product/UPDATE_RESERVATION_SUCCESS': {
      // return produce(state, (draft) => {
      //   const productIndex = draft.findIndex((p) => p.id === action.id);
      // });
    }
    default:
      return state;
  }
}
